using FirUnityEditor;
using System;
using UnityEditor;
using UnityEngine;

public enum ScenePosition { MapPosition, PuzzlePosition, Other }
public class SceneManager : SinglBehaviour<SceneManager>, ILoadingManager
{
    private IScenePanel readingRoomScene
    {
        get
        {
            return (IScenePanel)SceneHUB.ReadingRoomSceneManager.GetValue();
        }
    }
    private IScenePanel menuScene
    {
        get
        {
            return (IScenePanel)SceneHUB.MenuSceneManager.GetValue();
        }
    }

    [SerializeField]
    private SceneMarks currentScene;
    private SceneMarks sceneToLoad;
    public static SceneMarks CurrentScene
    {
        get
        {
            return instance.currentScene;
        }
    }

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

        MemoryManager.InitializeSceneDictionary(currentScene);

        CheckingTheScene();

        MemoryManager.LoadScenes(LoadingQueue);
    }

    public static void SetSceneToPosition(GameObject gameObject, ScenePosition position)
    {
        switch (position)
        {
            case ScenePosition.MapPosition:
                gameObject.transform.SetParent(instance.mapParent);
                break;
            case ScenePosition.PuzzlePosition:
                gameObject.transform.SetParent(instance.puzzleParent);
                break;
        }
    }

    //public static IEnumerator PreLoadScene(string sceneName)
    //{
    //    yield return null;

    //    instance.operation = UnitySceneManager.LoadSceneAsync(sceneName);
    //    instance.SetAllowSceneActivation(false);
    //    while (!instance.operation.isDone)
    //    {
    //        yield return null;
    //    }
    //}

    public static void LoadScene(SceneMarks scene)
    {
        instance.sceneToLoad = scene;

        if(!instance.TheSceneHasLoaded())
            MemoryManager.LoadScene(scene);

        instance.loadingTransitionOperator.LoadScene();
    }

    public bool TheSceneHasLoaded()
    {
        return MemoryManager.isSceneIsReady(sceneToLoad);
    }

    //public void SetAllowSceneActivation(bool v)
    //{
    //    instance.operation.allowSceneActivation = v;
    //}

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
                SceneMarks currentScene = instance.currentScene;
                if (currentScene == SceneMarks.readingRoom || currentScene == SceneMarks.puzzles)
                {
                    readingRoomScene.BasicPanelSettings();
                }
                else if (currentScene == SceneMarks.menu)
                {
                    menuScene.BasicPanelSettings();
                }
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