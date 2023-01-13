using FirSaveLoad;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Story
{
    public class StoryReader : MonoBehaviour
    {
        public TextAsset StoryFile;
        public List<List<string>> StoryData;
        public List<StoryComponent> Story;

        public TextMeshProUGUI text;

        public static List<List<StoryComponent>> GetFullStory(TextAsset[] storyFiles)
        {
            var Story = new List<List<StoryComponent>>();

            for (int i = 0; i < storyFiles.Length; i++)
            {
                List<StoryComponent> resultAct = new List<StoryComponent>();
                List<List<string>> textAct = StringReader.GetData(storyFiles[i]);

                foreach(List<string> separateString in textAct)
                {
                    int separateStringCount = separateString.Count;
                    string[] texts = new string[separateStringCount - StoryComponent.TEXT_COLLUM];
                    for(int j = 0; j < texts.Length; j++)
                    {
                        texts[j] = separateString[StoryComponent.TEXT_COLLUM + j];
                    }
                    //StoryComponent newStoryComponent =
                    //    new StoryComponent(texts);
                            //Act = i);
        //Scene;
        //Position;
        //Direction;
        //Emotion;
        //Character;
        //Text;);
                    //resultAct.Add(newStoryComponent);
                }
                Story.Add(resultAct);
            }

            return Story;
        }
    }
}