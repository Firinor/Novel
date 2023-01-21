using FirNovel.Characters;
using FirUnityEditor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    private TextMeshProUGUI textInCenterOfScreen;

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
	private Dictionary<CharacterInformator, SpeakerOperator> characters 
		= new Dictionary<CharacterInformator, SpeakerOperator>();
	private SpeakerOperator activeCharacter;

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
        CleareAll();
		LanguageManager.OnLanguageChange += ResetText;
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

	public void CleareAll()
    {
		ClearAllText();
        OffBackground();
        HideAllCharacters();
        HideAllWays();
        //music off
    }
	public void SetSceneName(string name)
	{
		sceneName.text = name;
    }

    #region Text
    private void HideText()
    {
        textCanvas.SetActive(false);
    }
    private void ShowText()
    {
        textCanvas.SetActive(true);
    }
    private void ClearAllText()
    {
        textMeshPro.text = "";
        textInCenterOfScreen.text = "";
    }
    private void ResetText()
	{
		SwichLanguage = true;
		ResetPlaqueName();
	}
	public void SetLettersDelay(float delta)
	{
		lettersDelay = delta;
	}
	public async Task PrintText(string[] text, bool senterScreen = false)
	{
		PrintableText = TextByLanguage(text);
        nextInput = false;
		nextArrow.enabled = false;

		strindBuilder.Clear();

        TextMeshProUGUI textComponent = senterScreen ? textInCenterOfScreen : textMeshPro;

		if (senterScreen)
		{
            ContentSizeFitter sizeFitter = textComponent.GetComponent<ContentSizeFitter>();
			if(sizeFitter != null)
			{
                textComponent.text = PrintableText;
				sizeFitter.SetLayoutVertical();
			}
        }
			
        textComponent.text = strindBuilder.ToString();

		for (int i = 0; i < PrintableText.Length + fullLineDelay; i++)
		{
			if(i < PrintableText.Length)
			{
				strindBuilder.Append(PrintableText[i]);
                textComponent.text = strindBuilder.ToString();
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
        textComponent.text = TextByLanguage(text);
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
                textComponent.text = TextByLanguage(text);
			}
			if (DialogManager.IsCancellationRequested)
				break;
			await Task.Yield();
		}
		ClearAllText();
    }
	private static string TextByLanguage(string[] text)
	{
		if(text == null)
			return null;
		if(text.Length == 0)
			return null;
		if(text.Length <= (int)PlayerManager.Language)
			return null;

		return text[(int)PlayerManager.Language];
	}
    #endregion

    #region Speakers
    public Task Say(CharacterInformator character, string[] text)
    {
        if (DialogManager.IsCancellationRequested)
            return Task.CompletedTask;

        SetPlaqueName(character);
        SetActiveCharacter(character);
        return PrintText(text);
    }
    public Task Say(string[] text)
    {
        if (DialogManager.IsCancellationRequested)
            return Task.CompletedTask;

        SetPlaqueName();
        return PrintText(text);
    }
    private Task PrintText(string[] text)
    {
        if (DialogManager.IsCancellationRequested)
            return Task.CompletedTask;

        return PrintText(text, senterScreen: false);
    }

    public void HideCharacter(CharacterInformator character)
	{
		SpeakerOperator speakerOperator = null;

		if (characters.ContainsKey(character))
		{
			speakerOperator = characters[character];
			characters.Remove(character);
		}

		if (speakerOperator != null)
			Destroy(speakerOperator.gameObject);
	}
	public void HideAllCharacters()
	{
		plaqueWithTheName.SetActive(false);
		characters.Clear();

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
	public void ShowCharacter(CharacterInformator character)
	{
		if (character == null)
			return;

		if (!characters.ContainsKey(character))
		{
			var speakerOperator = Instantiate(speakerPrefab, GetSpeakerParent()).GetComponent<SpeakerOperator>();
			speakerOperator.SetCharacter(character);
			characters.Add(character, speakerOperator);
		}
	}
    public void SetCharacters(List<CharacterStatus> characters)
    {
		if (characters == null)
			return;

        for(int i = 0; i < characters.Count; i++)
		{
			ShowCharacter(characters[i].Character);
			SetPosition(characters[i].Character, characters[i].Position, characters[i].ViewDirection);
        }
    }
    public void SetPosition(CharacterInformator character, PositionOnTheStage position, ViewDirection viewDirection)
	{
		if (character == null)
			return;

		if (!characters.ContainsKey(character))
			return;

		if(viewDirection == ViewDirection.Default)
			viewDirection = GetDefaultViewDirection(position);

		characters[character].transform.SetParent(GetSpeakerParent(position));
		characters[character].transform.localScale = new Vector3((int)viewDirection*(int)character.ViewDirection, 1, 1);
    }

	private ViewDirection GetDefaultViewDirection(PositionOnTheStage position)
	{
        if (position == PositionOnTheStage.Right)
            return ViewDirection.Left;

        return ViewDirection.Right;
    }

	public void SetActiveCharacter(CharacterInformator character)
	{
		if (character == null || !characters.ContainsKey(character))
			SetActiveCharacter((SpeakerOperator)null);
		else
			SetActiveCharacter(characters[character]);
	}
	public void SetActiveCharacter(SpeakerOperator character)
	{
		if (activeCharacter == character)
			return;
		DeactiveCharacter();
        if (character == null)
			return;
		if (!characters.ContainsValue(character))
			return;

		activeCharacter = character;
		activeCharacter.ToTheForeground();
	}

    public void DeactiveCharacter()
    {
        if (activeCharacter != null)
        {
            activeCharacter.ToTheBackground();
            activeCharacter = null;
        }
    }

    public void SetPlaqueName(CharacterInformator character = null)
	{
		if (character == null)
		{
			plaqueWithTheName.SetActive(false);
			return;
		}

		plaqueWithTheName.SetActive(true);
		speakerName.text = character.Name;
	}

    protected void ResetPlaqueName()
	{
		if(activeCharacter != null)
		{
			SetPlaqueName(activeCharacter.characterInformator);
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
    public async Task ShowImage(Sprite sprite, string[] text = null)
	{
		StopDialogSkip();
        nextInput = false;
		HideAllCharacters();
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
		if (!String.IsNullOrEmpty(TextByLanguage(text)))
		{
			await PrintText(text, senterScreen: true);
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

	public void CreateWayButton(DialogNode dialogNode, string description)
	{
		GameObject button = Instantiate(buttonPrefab, buttonParent.transform);
		button.GetComponent<DialogButtonOperator>().SetWay(dialogNode, description);
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
