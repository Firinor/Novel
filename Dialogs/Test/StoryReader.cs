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
        private static int sceneInt,
            backgroundInt,
            positionInt,
            directionInt,
            emotionInt,
            characterInt;

        private static Dictionary<Languages, int> columnsLanguage;
        private static IEnumerable<Languages> Languages;

        public static FullStory GetFullStory(TextAsset[] storyFiles)
        {
            Languages = Enum.GetValues(typeof(Languages)).Cast<Languages>();
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
            List<Scene> resultAct = new List<Scene>();
            List<StoryComponent> resultScene = new List<StoryComponent>();

            AnalyzeСolumns(textAct[0]);

            foreach (List<string> separateString in textAct)
            {
                if (string.IsNullOrEmpty(separateString[sceneInt]))
                {
                    resultAct.Add(resultScene);
                    resultScene = new List<StoryComponent>();
                }

                resultScene.Add(newStoryComponent(separateString));
            }
            resultAct.Add(resultScene);
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
        }

        private static StoryComponent newStoryComponent(List<string> separateString)
        {
            string[] texts = GetTexts(separateString);

            StoryComponent newStoryComponent =
               new StoryComponent(
                   scene: separateString[sceneInt],
                   background: separateString[backgroundInt],
                   position: separateString[positionInt],
                   direction: separateString[directionInt],
                   emotion: separateString[emotionInt],
                   character: separateString[characterInt],
                   text: texts);
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