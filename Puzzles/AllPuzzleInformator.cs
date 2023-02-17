using FirUnityEditor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AllPuzzleInformator : SinglBehaviour<AllPuzzleInformator>
{
    [SerializeField, NullCheck]
    private GameObject helpButtons;
    public GameObject HelpButtons{get { return helpButtons;}}

    [SerializeField, NullCheck]
    private GameObject victoryButton;
    public GameObject VictoryButton { get { return victoryButton; } }
    [SerializeField, NullCheck]
    private GameObject failButton;
    public GameObject FailButton { get { return failButton; } }
    [SerializeField, NullCheck]
    private GameObject retryButton;
    public GameObject RetryButton { get { return retryButton; } }

    [SerializeField, NullCheck]
    private Button exitButton;
    public Button ExitButton { get { return exitButton; } }
    [SerializeField, NullCheck]
    private Button optionsButton;
    public Button OptionsButton { get { return optionsButton; } }

    [SerializeField, NullCheck]
    private TextMeshProUGUI timerText;
    public TextMeshProUGUI TimerText { get { return timerText; } }

    void Awake()
    {
        SingletoneCheck(this);
    }
}
