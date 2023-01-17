using FirSaveLoad;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static StoryInformator;

namespace Story
{
    public class StoryReader
    {
        public static bool TEST_MODE = false;

        private static int sceneInt,
            backgroundInt,
            positionInt,
            directionInt,
            emotionInt,
            characterInt;

        private static string sceneValue;

        private static Dictionary<Languages, int> columnsLanguage;
        private static IEnumerable<Languages> Languages;

        public static FullStory GetFullStory(TextAsset[] storyFiles)
        {
            Languages = Enum.GetValues(typeof(Languages)).Cast<Languages>();
            columnsLanguage = new Dictionary<Languages, int>();
            sceneValue = "";

            var Story = new List<Act>();

            for (int i = 0; i < storyFiles.Length; i++)
            {
                List<List<string>> textAct = StringReader.GetData(storyFiles[i], startLine: 0, split: '\t');
                Act resultAct = GetAct(textAct);

                Story.Add(resultAct);
            }

            return Story;

        }

        private static Act GetAct(List<List<string>> textAct)
        {
            if (textAct == null || textAct.Count == 0)
                throw new Exception("textAct must be with some data!");

            List<Scene> resultAct = new List<Scene>();
            List<StoryComponent> resultScene = new List<StoryComponent>();

            AnalyzeСolumns(textAct[0]);

            string globalErrors = "";

            for (int i = 1; i < textAct.Count; i++)
            {
                if (!string.IsNullOrEmpty(textAct[i][sceneInt]))
                {
                    resultAct.Add(resultScene);
                    resultScene = new List<StoryComponent>();
                }
                string localErrors = "";
                StoryComponent newStoryComponent = GetStoryComponent(textAct[i], ref localErrors);
                if (!string.IsNullOrEmpty(localErrors))
                {
                    globalErrors += Environment.NewLine + $"Error in line {i}: " + localErrors;
                }
                resultScene.Add(newStoryComponent);
            }
            resultAct.Add(resultScene);
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

        private static StoryComponent GetStoryComponent(List<string> separateString, ref string errors)
        {
            string[] texts = GetTexts(separateString);

            StoryComponent newStoryComponent = new StoryComponent();

            if (string.IsNullOrEmpty(separateString[sceneInt]))
                separateString[sceneInt] = sceneValue;
            else
                sceneValue = separateString[sceneInt];

            try
            {
                newStoryComponent.SetValues(
                   scene: separateString[sceneInt],
                   background: separateString[backgroundInt],
                   position: separateString[positionInt],
                   direction: separateString[directionInt],
                   emotion: separateString[emotionInt],
                   character: separateString[characterInt],
                   text: texts);
            }
            catch (InvalidCastException e)
            {
                errors = e.Message;
            }

            return newStoryComponent;
        }

        private static string[] GetTexts(List<string> separateString)
        {
            string[] texts = new string[columnsLanguage.Count];
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