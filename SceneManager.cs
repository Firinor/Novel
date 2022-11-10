using System;
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
        optionsOperator.SingletoneCheck(optionsOperator);//Singltone

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

    public static bool MenuScene()
    {
        return GetScene() == 0;
    }

    public static void LoadScene(string sceneName)
    {
        instance.operation = UnitySceneManager.LoadSceneAsync(sceneName);
        instance.SetAllowSceneActivation(false);
        instance.loadingTransitionOperator.LoadScene();
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
        if (SceneIndex == 1)//"ReadingRoom"
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
        if (SceneIndex == 1)//"ReadingRoom"
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