using System;
using System.Collections.Generic;
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

            char newDialog = '\"';
            string newLine = Environment.NewLine;

            //for (int i = startLine; i < data.Length; i++)
            //{
            //    string unitString = data[i].Replace("\"", "");
            //    string[] elements = unitString.Split(split);

            //    if (elements.Length == 0)
            //        continue;

            //    Result.Add(new List<string>(elements));
            //}

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
