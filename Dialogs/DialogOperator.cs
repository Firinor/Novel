using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

public class DialogOperator : SinglBehaviour<DialogOperator>
{
    [SerializeField]
    private GameObject speakerPrefab;
    [SerializeField]
    private GameObject buttonPrefab;
    [SerializeField]
    private GameObject buttonParent;
    [SerializeField]
    private GameObject plaqueWithTheName;
    [Space]
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Image background;
    [SerializeField]
    private Sprite defaultSprite;
    [SerializeField]
    private GameObject leftSpeaker;
    [SerializeField]
    private GameObject centerSpeaker;
    [SerializeField]
    private GameObject rightSpeaker;
    [SerializeField]
    private TextMeshProUGUI speakerName;
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    [SerializeField]
    private float lettersDelay;
    [SerializeField]
    private Image nextArrow;

    private StringBuilder strindBuilder = new StringBuilder();
    private Dictionary<CharacterInformator, SpeakerOperator> speakers = new Dictionary<CharacterInformator, SpeakerOperator>();
    private SpeakerOperator activeSpeaker;

    private static bool nextInput;
    public static void NextInput() => nextInput = true;

    private static bool skipText;
    public static void SkipText() => skipText = true;

    public static int OrderLayer { get { return instance.canvas.sortingOrder; } }
    public static GameObject Left { get { return instance.leftSpeaker; } }
    public static GameObject Center { get { return instance.centerSpeaker; } }
    public static GameObject Right { get { return instance.rightSpeaker; } }

    #region Text
    public void SetLettersDelay(float delta)
    {
        lettersDelay = delta;
    }
    public async Task PrintText(string text)
    {
        nextInput = false;
        skipText = false;
        nextArrow.enabled = false;

        strindBuilder.Clear();

        textMeshPro.text = strindBuilder.ToString();

        for (int j = 0; j < text.Length; j++)
        {
            strindBuilder.Append(text[j]);
            textMeshPro.text = strindBuilder.ToString();
            if (skipText)
            {
                break;
            }
            if (nextInput)
            {
                j = text.Length;
                textMeshPro.text = text;
                nextInput = false;
            }
            await Task.Delay((int)(lettersDelay * 1000));
        }
        nextArrow.enabled = true;
        while (!nextInput)
        {
            if (skipText)
            {
                break;
            }
            await Task.Yield();
        }
    }
    #endregion

    #region Speakers
    public void RemoveSpeaker(CharacterInformator speaker)
    {
        SpeakerOperator speakerOperator = null;

        if (speakers.ContainsKey(speaker))
        {
            speakerOperator = speakers[speaker];
            speakers.Remove(speaker);
        }

        if (speakerOperator != null)
            Destroy(speakerOperator.gameObject);
    }
    public void ClearAllSpeakers()
    {
        plaqueWithTheName.SetActive(false);
        speakers.Clear();

        List<SpeakerOperator> gameObjectToDelete = new List<SpeakerOperator>();
        AllSpeakersIn(gameObjectToDelete, leftSpeaker);
        AllSpeakersIn(gameObjectToDelete, centerSpeaker);
        AllSpeakersIn(gameObjectToDelete, rightSpeaker);

        foreach (SpeakerOperator speaker in gameObjectToDelete)
        {
            Destroy(speaker.gameObject);
        }
    }
    private void AllSpeakersIn(List<SpeakerOperator> gameObjectToDelete, GameObject side)
    {
        foreach (SpeakerOperator gameObject in side.GetComponentsInChildren<SpeakerOperator>())
        {
            gameObjectToDelete.Add(gameObject);
        }
    }
    public void AddSpeaker(CharacterInformator speaker)
    {
        if (speaker == null)
            return;

        if (!speakers.ContainsKey(speaker))
        {
            var speakerOperator = Instantiate(speakerPrefab, GetSpeakerParent()).GetComponent<SpeakerOperator>();
            speakerOperator.SetCharacter(speaker);
            speakers.Add(speaker, speakerOperator);
        }
    }
    public void SetPosition(CharacterInformator speaker, PositionOnTheStage position)
    {
        if (speaker == null)
            return;

        if (!speakers.ContainsKey(speaker))
            return;

        speakers[speaker].transform.SetParent(GetSpeakerParent(position));
    }
    public void SetActiveSpeaker(CharacterInformator speaker)
    {
        if (!speakers.ContainsKey(speaker))
            SetActiveSpeaker((SpeakerOperator)null);
        else
            SetActiveSpeaker(speakers[speaker]);
    }
    public void SetActiveSpeaker(SpeakerOperator speaker)
    {
        if (activeSpeaker == speaker)
            return;
        if (activeSpeaker != null)
        {
            activeSpeaker.ToTheBackground();
            activeSpeaker = null;
        }
        if (speaker == null)
            return;
        if (!speakers.ContainsValue(speaker))
            return;

        activeSpeaker = speaker;
        activeSpeaker.ToTheForeground();
    }
    public void SetPlaqueName(CharacterInformator speaker = null)
    {
        if (speaker == null)
        {
            plaqueWithTheName.SetActive(false);
            return;
        }

        plaqueWithTheName.SetActive(true);
        speakerName.text = speaker.Name;
    }
    private Transform GetSpeakerParent(PositionOnTheStage position = PositionOnTheStage.Center)
    {
        return position switch
        {
            PositionOnTheStage.Left => leftSpeaker.transform,
            PositionOnTheStage.Right => rightSpeaker.transform,
            PositionOnTheStage.Center => centerSpeaker.transform,
            _ => centerSpeaker.transform,
        };
    }
    #endregion

    #region Background
    public void SetBackground(Sprite background)
    {
        if (background != null)
            this.background.sprite = background;
    }
    public void OffBackground()
    {
        background.sprite = defaultSprite;
    }
    #endregion

    #region Ways
    public void HideAllWays()
    {
        var childs = buttonParent.GetComponentsInChildren<DialogButtonOperator>();

        foreach (DialogButtonOperator child in childs)
        {
            Destroy(child.gameObject);
        }
    }

    public void CreateWayButton(DialogNode dialogNode)
    {
        GameObject button = Instantiate(buttonPrefab, buttonParent.transform);
        button.GetComponent<DialogButtonOperator>().SetWay(dialogNode);
    }
    #endregion

    public void Options() => ReadingRoomManager.SwitchPanels(ReadingRoomMarks.options);
    public void EndOfDialog() => gameObject.SetActive(false);
}
