using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FirSaveLoad
{
    public static class StringReader
    {
        public static List<List<string>> GetData(TextAsset textFile, int startLine = 1, char split = ';')
        {
            return GetData(textFile.text, startLine, split);
        }
        public static List<List<string>> GetData(string text, int startLine = 1, char split = ';')
        {
            List<List<string>> Result = new List<List<string>>();

            string newDialog = "\"";
            string[] newLine = new string[] { Environment.NewLine };
            string newLineString = Environment.NewLine;

            string[] textSplited = text.Split(split);

            List<string> storyScene = new List<string>();
            bool isPhraseMovedToNewLine = false;

            foreach (string pieceOfText in textSplited)
            {
                if (pieceOfText.StartsWith(newDialog))
                {
                    isPhraseMovedToNewLine = true;
                }
                
                if (pieceOfText.Contains(newLineString))
                {
                    //...end of line.{Environment.NewLine}
                    //begin of new line...

                    string[] betweenLines = pieceOfText.Split(newLine, StringSplitOptions.None);

                    //betweenLines[0] = end of line
                    //betweenLines[1] = begin of new line

                    if (isPhraseMovedToNewLine)
                    {
                        if (betweenLines[0].EndsWith(newDialog))
                        {
                            isPhraseMovedToNewLine = false;
                        }
                    }
                    else
                    {
                        storyScene.Add(betweenLines[0]);
                        Result.Add(storyScene);
                        storyScene = new List<string>();
                        storyScene.Add(betweenLines[1]);
                    }
                    
                }

                

            }
            //.Replace("\"", "");
            //    string[] elements = unitString.Split(split);

            //    if (elements.Length == 0)
            //        continue;

            Result.Add(storyScene);

            return Result;
        }

        public static List<List<string>> GetData(string[] data, int startLine = 1, char split = ';')
        {
            List<List<string>> Result = new List<List<string>>();

            for (int i = startLine; i < data.Length; i++)
            {
                string unitString = data[i].Replace("\"", "");
                string[] elements = unitString.Split(split);

                if (elements.Length == 0)
                    continue;

                Result.Add(new List<string>(elements));
            }

            return Result;
        }
    }
}
