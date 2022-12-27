using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace FirSaveLoad
{
    public class CSVReader
    {
        //[SerializeField]
        //private string pathToFile = "/Units/_UnitData.csv";

        public static List<List<string>> GetData(string pathToFile, int startLine = 1)
        {
            string path = Application.dataPath + pathToFile;

            string[] AllText = File.ReadAllLines(path);

            List<List<string>> Result = new List<List<string>>();

            for (int i = startLine; i < AllText.Length; i++)
            {
                string unitString = AllText[i].Replace("\"", "");
                string[] elements = unitString.Split(';');

                if (elements.Length == 0)
                    continue;

                Result.Add(new List<string>(elements));
            }

            return Result;
        }
    }
}
