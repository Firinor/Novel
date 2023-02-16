using FirUnityEditor;
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public enum ScenePosition { mapPosition, puzzlePosition }
public class SceneManager : SinglBehaviour<SceneManager>, ILoadingManager
{
    public static IScenePanel ScenePanel { get; set; }
    private AsyncOperation operation;
    [SerializeField]
    private SceneMarks currentScene;

    [SerializeField]
    private SceneMarks[] LoadingQueue;

    [SerializeField, NullCheck]
    private GameObject optionsPanel;
    private OptionsOperator optionsOperator;
    [SerializeField, NullCheck]
    private LoadingTransitionOperator loadingTransitionOperator;
    [SerializeField, NullCheck]
    private GameObject[] doNotDestroyOnLoad;

    [SerializeField, NullCheck]
    private Transform puzzleParent;
    [SerializeField, NullCheck]
    private Transform mapParent;

    void Awake()
    {
        if (!SingletoneCheck(this))
            return;

        optionsOperator = optionsPanel.GetComponent<OptionsOperator>();
        //optionsOperator is disabled. Awake & Start procedures are not suitable
        optionsOperator.SingletoneCheck(optionsOperator);

        foreach (GameObject go in doNotDestroyOnLoad)
        {
            if (go != null)
            {
                DontDestroyOnLoad(go);
            }
        }

        MemoryManager.InitializeSceneDictionary();

        //CheckingTheScene();

        MemoryManager.LoadScenes(LoadingQueue);
    }

    public static void SetSceneToPosition(GameObject gameObject, ScenePosition position)
    {
        switch (position)
        {
            case ScenePosition.mapPosition:
                gameObject.transform.SetParent(instance.mapParent);
                break;
            case ScenePosition.puzzlePosition:
                gameObject.transform.SetParent(instance.puzzleParent);
                break;
        }
    }

    public static IEnumerator PreLoadScene(string sceneName)
    {
        yield return null;

        instance.operation = UnitySceneManager.LoadSceneAsync(sceneName);
        instance.SetAllowSceneActivation(false);
        while (!instance.operation.isDone)
        {
            yield return null;
        }
    }

    public static void LoadScene(string sceneName)
    {
        if (sceneName != "ReadingRoom" || instance.operation == null || instance.operation.isDone)
            instance.StartCoroutine(PreLoadScene(sceneName));

        instance.loadingTransitionOperator.LoadScene();
    }

    public bool TheSceneHasLoaded()
    {
        if (operation == null)
            return false;

        return operation.isDone;
    }

    public void SetAllowSceneActivation(bool v)
    {
        instance.operation.allowSceneActivation = v;
    }

    public static void SwitchPanel(SceneDirection direction)
    {
        instance.SwitchPanels(direction);
    }

    public void SwitchPanels(SceneDirection direction)
    {
        switch (direction)
        {
            case SceneDirection.options:
                instance.optionsPanel.SetActive(true);
                break;
            case SceneDirection.exit:
                DiactiveAllPanels();
                ExitAction();
                break;
            case SceneDirection.basic:
                ScenePanel.BasicPanelSettings();
                break;
            default:
                throw new Exception("Unrealized bookmark!");
        }
    }

    private static void ExitAction()
    {
        SceneMarks currentScene = instance.currentScene;
        if (currentScene == SceneMarks.readingRoom || currentScene == SceneMarks.puzzles)
        {
            //LoadScene("MainMenu");
        }
        else if (currentScene == SceneMarks.menu)
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        else
        {
            throw new Exception("Error on exit button!");
        }
    }

    public static void DiactiveAllPanels()
    {
        instance.optionsPanel.SetActive(false);
    }

    public static void CheckingTheScene()
    {
        SceneMarks currentScene = instance.currentScene;
        if (currentScene == SceneMarks.readingRoom || currentScene == SceneMarks.puzzles)
        {
            FindObjectOfType<ReadingRoomManager>().SetAllInstance();
        }
        else if (currentScene == SceneMarks.menu)
        {
            FindObjectOfType<MainMenuManager>().SetAllInstance();
        }
        else
        {
            throw new Exception("Error on checking scene!");
        }
    }
}