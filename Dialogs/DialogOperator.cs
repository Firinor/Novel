using FirUnityEditor;
using Puzzle;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    //[SerializeField, NullCheck]
    //private MapCanvasOperator mapCanvasOperator;
    [SerializeField]
	private float lettersDelay;
	[SerializeField, NullCheck]
    private Image nextArrow;

	private StringBuilder strindBuilder = new StringBuilder();
	private bool SwichLanguage;
	private string PrintableText;
	private Dictionary<CharacterInformator, SpeakerOperator> speakers 
		= new Dictionary<CharacterInformator, SpeakerOperator>();
	private SpeakerOperator activeSpeaker;

	public static bool skipText;
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
	#endregion

	#region Text
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

		for (int i = 0; i < PrintableText.Length; i++)
		{
			strindBuilder.Append(PrintableText[i]);
			textMeshPro.text = strindBuilder.ToString();
			if (skipText)
			{
				break;
			}
			if (nextInput)
			{
				i = PrintableText.Length;
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

	public void DialogSkip() => skipText = true;
	public void Options() => DialogManager.Options();
	public void DialogExit()
	{
		DialogManager.StopDialog();
		OffBackground();
        gameObject.SetActive(false);
	}
}
