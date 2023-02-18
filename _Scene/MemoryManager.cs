using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public enum SceneMarks
{
    menu, readingRoom, puzzles, dialog, allPuzzles,
    findObject, tetraQuestion, findDifferences, searchObjects,
    spectralAnalysis, DNA, nand, chemical, starMap, bossBattle
};

public static class MemoryManager
{
    private static Dictionary<SceneMarks, bool> scenesInGame;
    private static AsyncOperation operation;

    public static void InitializeSceneDictionary()
    {
        scenesInGame = new Dictionary<SceneMarks, bool>();
        
        for(int i = 0; i < UnitySceneManager.sceneCountInBuildSettings; i++)
        {
            scenesInGame.Add((SceneMarks)i, false);
        }
    }

    public static async Task LoadScene(SceneMarks mark)
    {
        while(operation != null)
        {
            Debug.Log($"Scene {mark} in queue: at {DateTime.Now}");
            await Task.Yield();
        }

        if (scenesInGame[mark])
            return;

        Debug.Log($"Start load scene {mark}: at {DateTime.Now}");
        operation = UnitySceneManager.LoadSceneAsync((int)mark);
        int i = 0;
        while (!operation.isDone)
        {
            i++;
            Debug.Log(i);
            await Task.Yield();
        }

        scenesInGame[mark] = true;
        operation = null;
        Debug.Log($"End load scene {mark}: at {DateTime.Now}");
    }

    public static async void LoadScenes(SceneMarks[] loadingQueue)
    {
        for(int i = 0; i < loadingQueue.Length;i++)
        {
            await LoadScene(loadingQueue[i]);
        }
    }
}
