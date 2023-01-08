using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : SinglBehaviour<SceneManager>, ILoadingManager
{
    public static IScenePanel ScenePanel { get; set; }
    private AsyncOperation operation;

    [SerializeField]
    private GameObject optionsPanel;
    private OptionsOperator optionsOperator;
    [SerializeField]
    private LoadingTransitionOperator loadingTransitionOperator;
    [SerializeField]
    private GameObject[] doNotDestroyOnLoad;

    void Awake()
    {
        SingletoneCheck(this);

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

        CheckingTheScene();
    }

    public static int GetScene()
    {
        return UnitySceneManager.GetActiveScene().buildIndex;
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
        int SceneIndex = GetScene();
        if (SceneIndex == 1 || SceneIndex == 2)//"ReadingRoom" or "PuzzleRoom"
        {
            LoadScene("MainMenu");
        }
        else if (SceneIndex == 0)//"MainMenu"
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
        int SceneIndex = GetScene();
        if (SceneIndex == 1 || SceneIndex == 2)//"ReadingRoom" or "PuzzleRoom"
        {
            FindObjectOfType<ReadingRoomManager>().SetAllInstance();
        }
        else if (SceneIndex == 0)//"MainMenu"
        {
            FindObjectOfType<MainMenuManager>().SetAllInstance();
        }
        else
        {
            throw new Exception("Error on checking scene!");
        }
    }
}