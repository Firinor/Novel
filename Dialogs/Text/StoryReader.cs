﻿using FirNovel.Characters;
using FirParser;
using FirSaveLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static StoryInformator;
using Episode = StoryInformator.Episode;

namespace Story
{
    public class StoryReader
    {
        public static bool TEST_MODE = false;

        private static int sceneInt,
            functionInt,
            backgroundInt,
            positionInt,
            directionInt,
            emotionInt,
            characterInt;

        private static int sceneValue;
        private static Sprite backgroundValue;

        private static Dictionary<Languages, int> columnsLanguage;
        private static IEnumerable<Languages> Languages;
        private static StoryInformator informator;

        public static FullStory GetFullStory(TextAsset[] storyFiles, StoryInformator informator)
        {
            StoryReader.informator = informator;
            ResetColumnInt();
            Languages = Enum.GetValues(typeof(Languages)).Cast<Languages>();
            columnsLanguage = new Dictionary<Languages, int>();
            sceneValue = -1;
            backgroundValue = informator.backgrounds.None;

            var Story = new List<Act>();

            for (int i = 0; i < storyFiles.Length; i++)
            {
                List<List<string>> textAct = StringReader.GetData(storyFiles[i], startLine: 0, split: '\t');
                Act resultAct = GetAct(textAct);

                Story.Add(resultAct);
            }

            return Story;

        }

        private static void ResetColumnInt()
        {
            sceneInt =
            functionInt =
            backgroundInt =
            positionInt =
            directionInt =
            emotionInt =
            characterInt = -1;
        }

        private static Act GetAct(List<List<string>> textAct)
        {
            if (textAct == null || textAct.Count == 0)
                throw new Exception("textAct must be with some data!");

            List<Episode> resultAct = new List<Episode>();
            Episode resultEpisode = null;
            var Characters = new List<CharacterStatus>();

            AnalyzeСolumns(textAct[0]);

            string globalErrors = "";
            bool removeCharacter = false;
            CharacterInformator removeCharacterStatus = null;

            for (int i = 1; i < textAct.Count; i++)
            {
                string localErrors = "";

                //
                if (removeCharacter)
                {
                    for(int j = 0; j < Characters.Count; j++)
                    {
                        if(removeCharacterStatus == Characters[j].Character)
                        {
                            Characters.RemoveAt(j);
                            removeCharacter = false;
                            break;
                        }
                    }
                }

                //If there is new scene number, it's must building new result scene
                if (!string.IsNullOrEmpty(textAct[i][sceneInt]))
                {
                    if(resultEpisode != null)
                        resultAct.Add(resultEpisode);
                    resultEpisode = new Episode();
                    Characters = new List<CharacterStatus>();
                }

                if (textAct[i][functionInt].StartsWith("Choise"))
                {
                    MultiText texts = GetTexts(textAct[i]);
                    resultEpisode.AddChoice(texts);
                    continue;
                }

                //Generate StoryComponent
                StoryComponent newStoryComponent = GetStoryComponent(textAct[i], Characters, ref localErrors);

                //Errors check
                if (!string.IsNullOrEmpty(localErrors))
                {
                    globalErrors += Environment.NewLine + $"Error in line {i}: " + localErrors;
                }

                //If there is no text, it's need to continue building the story component
                if (newStoryComponent.Text == null)
                {
                    continue;
                }

                //The component is approved for the act
                resultEpisode.AddReplica(newStoryComponent);

                //
                if (textAct[i][functionInt] == "HideCharacter")
                {
                    removeCharacter = true;
                    removeCharacterStatus = newStoryComponent.Character;
                }
            }
            resultAct.Add(resultEpisode);
            if (!string.IsNullOrEmpty(globalErrors))
            {
                Debug.Log("========================== Act ==========================" + globalErrors);
            }
            return resultAct;
        }

        private static void AnalyzeСolumns(List<string> documentHeader)
        {
            for(int i = 0; i < documentHeader.Count;i++)
            {
                string column = documentHeader[i].ToLower();

                if(column == "scene")
                {
                    sceneInt = i;
                    continue;
                }
                if (column == "function")
                {
                    functionInt = i;
                    continue;
                }
                if (column == "background")
                {
                    backgroundInt = i;
                    continue;
                }
                if (column == "position")
                {
                    positionInt = i;
                    continue;
                }
                if (column == "direction")
                {
                    directionInt = i;
                    continue;
                }
                if (column == "emotion")
                {
                    emotionInt = i;
                    continue;
                }
                if (column == "character")
                {
                    characterInt = i;
                    continue;
                }
                foreach(var language in Languages)
                {
                    if(language.ToString().ToLower() == column)
                    {
                        columnsLanguage.Add(language, i);
                        break;
                    }
                }
            }
            #region Test
            if (TEST_MODE)
            {
                string testResult = $"sceneInt = {sceneInt};" +
                    $"functionInt = {functionInt};" +
                    $"backgroundInt = {backgroundInt};" +
                    $"positionInt = {positionInt};" +
                    $"directionInt = {directionInt};" +
                    $"emotionInt = {emotionInt};" +
                    $"characterInt = {characterInt};";
                foreach (var language in columnsLanguage)
                {
                    testResult += $"columnsLanguage{language.Key} = {language.Value};";
                }
                Debug.Log(testResult);
            }
            #endregion Test
        }

        private static StoryComponent GetStoryComponent(List<string> separateString,
            List<CharacterStatus> Characters, ref string errors)
        {
            MultiText texts = GetTexts(separateString);

            StoryComponent newStoryComponent = null;
            CharacterInformator Character;

            try
            {
                //scene
                if (!string.IsNullOrEmpty(separateString[sceneInt]))
                    sceneValue = int.Parse(separateString[sceneInt]);

                //background
                if (!string.IsNullOrEmpty(separateString[backgroundInt]))
                {
                    backgroundValue = StringParser.NotSafeFindField<Sprite>(
                        separateString[backgroundInt], informator.backgrounds);
                }

                //character
                if (!string.IsNullOrEmpty(separateString[characterInt]))
                {
                    Character = StringParser.NotSafeFindField<CharacterInformator>(
                        separateString[characterInt], informator.characters);
                }
                else Character = informator.characters.None;

                //characterStatus
                CharacterStatus CharStatus = new CharacterStatus(
                    Character,
                    position: separateString[positionInt],
                    direction: separateString[directionInt],
                    emotion: separateString[emotionInt]);

                //characters
                AddCharacter(Characters, CharStatus);

                //new StoryComponent
                newStoryComponent = new StoryComponent(
                   sceneValue,
                   separateString[functionInt],
                   backgroundValue,
                   Character,
                   Characters,
                   texts
                   );
            }
            catch (InvalidCastException e)
            {
                errors = e.Message;
            }

            return newStoryComponent;
        }

        private static void AddCharacter(List<CharacterStatus> characters, CharacterStatus characterStatus)
        {
            if (characters == null)
            {
                characters = new List<CharacterStatus>();
            }

            int characterIndex = -1;
            for (int i = 0; i < characters.Count; i++)
            {
                if (characters[i].Character == characterStatus.Character)
                {
                    characterIndex = i;
                    break;
                }
            }

            if (characterIndex != -1)
            {
                characters[characterIndex] = characterStatus;
            }
            else
            {
                characters.Add(characterStatus);
            }
        }

        private static MultiText GetTexts(List<string> separateString)
        {
            if (string.IsNullOrEmpty(separateString[columnsLanguage[global::Languages.RU]]))
            {
                return null;
            }

            MultiText texts = new MultiText(columnsLanguage.Count);
            int index = 0;
            foreach (Languages language in columnsLanguage.Keys)
            {
                texts[index] = separateString[columnsLanguage[language]];
                index++;
            }
            return texts;
        }
    }
}