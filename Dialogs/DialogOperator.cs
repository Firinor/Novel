using FirUnityEditor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class DialogOperator : SinglBehaviour<DialogOperator>
{
    #region Fields
    [SerializeField, NullCheck]
	private GameObject speakerPrefab;
	[SerializeField, NullCheck]
    private GameObject buttonPrefab;
	[SerializeField, NullCheck]
    private GameObject buttonParent;
	[SerializeField, NullCheck]
    private GameObject plaqueWithTheName;
	[Space]
	[SerializeField, NullCheck]
    private RectTransform rectTransform;
	[SerializeField, NullCheck]
    private Canvas canvas;
	[SerializeField, NullCheck]
    private Image backgroundImage;
	[SerializeField, NullCheck]
    private Sprite defaultSprite;
	[SerializeField, NullCheck]
    private GameObject leftSpeaker;
	[SerializeField, NullCheck]
    private GameObject centerSpeaker;
	[SerializeField, NullCheck]
    private GameObject rightSpeaker;
    [SerializeField, NullCheck]
    private TextMeshProUGUI sceneName;
    [SerializeField, NullCheck]
    private TextMeshProUGUI speakerName;
	[SerializeField, NullCheck]
    private TextMeshProUGUI textMeshPro;
    [SerializeField, NullCheck]
    private GameObject textCanvas;
    //[SerializeField, NullCheck]
    //private MapCanvasOperator mapCanvasOperator;
    [SerializeField]
	private float lettersDelay;
    //Delay after full line output
    private int fullLineDelay = 7;
    [SerializeField, NullCheck]
    private Image nextArrow;

	private StringBuilder strindBuilder = new StringBuilder();
	private bool SwichLanguage;
	private string PrintableText;
	private Dictionary<CharacterInformator, SpeakerOperator> speakers 
		= new Dictionary<CharacterInformator, SpeakerOperator>();
	private SpeakerOperator activeSpeaker;

    private static bool skipText;
	private static bool nextInput;
	public static void NextInput() => nextInput = true;

	public static float RectTransformHeight { get { return instance.rectTransform.rect.height; } }
	public static int OrderLayer { get { return instance.canvas.sortingOrder; } }
	public static GameObject Left { get { return instance.leftSpeaker; } }
	public static GameObject Center { get { return instance.centerSpeaker; } }
	public static GameObject Right { get { return instance.rightSpeaker; } }
    #endregion

    #region Monobehaviour
    void Awake()
	{
		LanguageManager.OnLanguageChange += ResetSpeakerNameAndText;
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.RightArrow)
            || Input.GetKeyDown(KeyCode.Space)
            || Input.GetKeyDown(KeyCode.KeypadEnter)
            || Input.GetKeyDown(KeyCode.Return))
		{
			NextInput();
		}
    }
    #endregion

    #region Text

    private void HideText()
    {
        textCanvas.SetActive(false);
    }

    private void ShowText()
    {
        textCanvas.SetActive(true);
    }

    private void ResetSpeakerNameAndText()
	{
		SwichLanguage = true;
		ResetPlaqueName();
	}

	public void SetLettersDelay(float delta)
	{
		lettersDelay = delta;
	}
	public async Task PrintText(string[] text)
	{
		PrintableText = TextByLanguage(text);
        nextInput = false;
		nextArrow.enabled = false;

		strindBuilder.Clear();

		textMeshPro.text = strindBuilder.ToString();

		for (int i = 0; i < PrintableText.Length + fullLineDelay; i++)
		{
			if(i < PrintableText.Length)
			{
                strindBuilder.Append(PrintableText[i]);
                textMeshPro.text = strindBuilder.ToString();
            }
			if (skipText)
			{
				break;
			}
			if (nextInput)
			{
				i = PrintableText.Length + fullLineDelay;
				nextInput = false;
			}
			if (DialogManager.IsCancellationRequested)
				break;
			if (SwichLanguage)
			{
				SwichLanguage = false;
				i = 0;
				PrintableText = TextByLanguage(text);
			}
			await Task.Delay((int)(lettersDelay * 1000));
		}
        textMeshPro.text = TextByLanguage(text);
		nextArrow.enabled = true;
		while (!nextInput)
		{
			if (skipText)
			{
				break;
			}
			if (SwichLanguage)
			{
				SwichLanguage = false;
				textMeshPro.text = TextByLanguage(text);
			}
			if (DialogManager.IsCancellationRequested)
				break;
			await Task.Yield();
		}
	}

	private static string TextByLanguage(string[] text)
	{
		return text[(int)PlayerManager.Language];
	}

	public void SetSceneName(string name)
	{
		sceneName.text = name;
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
    public void SetPosition(CharacterInformator speaker, PositionOnTheStage position, ViewDirection viewDirection)
	{
		if (speaker == null)
			return;

		if (!speakers.ContainsKey(speaker))
			return;

		speakers[speaker].transform.SetParent(GetSpeakerParent(position));
		speakers[speaker].transform.localScale = new Vector3((int)viewDirection*(int)speaker.ViewDirection, 1, 1);
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
		DeactiveSpeaker();
        if (speaker == null)
			return;
		if (!speakers.ContainsValue(speaker))
			return;

		activeSpeaker = speaker;
		activeSpeaker.ToTheForeground();
	}

    public void DeactiveSpeaker()
    {
        if (activeSpeaker != null)
        {
            activeSpeaker.ToTheBackground();
            activeSpeaker = null;
        }
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
    public void SetPlaqueName(string name_ru, string name_en)
    {
		String[] names = { name_ru, name_en };
        plaqueWithTheName.SetActive(true);
        speakerName.text = TextByLanguage(names);
    }

    protected void ResetPlaqueName()
	{
		if(activeSpeaker != null)
		{
			SetPlaqueName(activeSpeaker.characterInformator);
		}
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
		{
            backgroundImage.enabled = true;
            backgroundImage.sprite = background;
        }
		
	}
    public async Task ShowImage(Sprite sprite)
	{
		StopDialogSkip();
        nextInput = false;
		ClearAllSpeakers();
        HideText();
        SetBackground(sprite);
        while (!nextInput)
        {
            if (skipText)
                break;

            if (DialogManager.IsCancellationRequested)
                break;

            await Task.Yield();
        }
		OffBackground();
        ShowText();
    }
    public void OffBackground()
	{
        backgroundImage.enabled = false;
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

	public void StopDialogSkip() => skipText = false;
	public void DialogSkip() => skipText = true;
	public void Options() => DialogManager.Options();
	public void DialogExit()
	{
		DialogManager.StopDialog();
		OffBackground();
        gameObject.SetActive(false);
	}
}
