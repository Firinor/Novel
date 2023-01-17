using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using static StoryInformator;
using Scene = StoryInformator.Scene;

public enum PositionOnTheStage { OffScene, Left, Center, Right}
public enum DialogProgressStatus { Open, Closed, Hiden }

public class DialogNode : MonoBehaviour
{
    [SerializeField]
    private string[] Header = new string[2] { "русское название", "english name" };
    [SerializeField, Min(1)]
    private int Act;
    [SerializeField, Min(1)]
    private int Scene;
    [SerializeField]
    private List<DialogNode> Choices;
    private DialogProgressStatus dialogProgressStatus = DialogProgressStatus.Hiden;

    private DialogOperator dialogOperator;
    protected Characters Characters;
    protected Backgrounds Backgrounds;

    private Scene scene;
    private int incidentIndex;

    protected void Awake()
    {
        StoryInformator storyInformator = StoryInformator.instance;
        Characters = storyInformator.characters;
        Backgrounds = storyInformator.backgrounds;
        scene = storyInformator.GetScene(Act, Scene);
        dialogOperator = DialogOperator.instance;
        GetComponent<Button>().onClick.AddListener(StartDialog);

    }
    public void SetChoice(DialogNode dialogNode)
    {
        if (dialogNode == null)
            return;

        Choices = new List<DialogNode>() { dialogNode };
    }
    public string GetHeader()
    {
        return Header[(int)PlayerManager.Language];
    }
    public virtual void StartDialog()
    {
        DialogManager.ActivateDialog(GetComponent<RectTransform>());
        CleareAll();
        dialogOperator.SetSceneName(name);
        StartScene();
    }
    public async void StartScene()
    {
        incidentIndex = 0;
        for (; incidentIndex < scene.Length;)
        {
            await scene[incidentIndex].Action();
            incidentIndex++;
        }
        
        //CharacterInformator Skull = Characters.Skull;
        CharacterInformator Archmagister = Characters.Cristopher;
        //Scene(Backgrounds.Lab);
        Show(Archmagister, PositionOnTheStage.Right, ViewDirection.Left);
        await Say(Archmagister, "Дитя мое, настал день твоего экзамена." +
            " Вечером ты уже будешь признанным магистром и мы сможем отпраздновать.", "");
        await Say(Archmagister, "Принимать экзамен будет наимудрейший беспристрастный основатель нашего ордена," +
            " лучше других знающий к каким последствиям приводит риск в нашем деле.", "");

    }
        public void StartDialog(int index)
    {
        if(Choices != null && Choices.Count > index)
            Choices[index]?.StartDialog();
    }

    public void CleareAll()
    {
        SceneOff();
        HideAllSpeakers();
        HideAllWays();
        //music off
    }

    private void HideAllWays()
    {
        dialogOperator.HideAllWays();
    }

    public Task SayByName(CharacterInformator character, string name_ru, string name_en, string text_ru, string text_en)
    {
        if (DialogManager.IsCancellationRequested)
            return Task.CompletedTask;

        dialogOperator.SetPlaqueName(name_ru, name_en);
        if (character != null)
            dialogOperator.SetActiveSpeaker(character);
        else
            dialogOperator.DeactiveSpeaker();
        return PrintText(new string[2] { text_ru, text_en });
    }

    public Task Say(CharacterInformator character, string text_ru, string text_en)
    {
        if (DialogManager.IsCancellationRequested)
            return Task.CompletedTask;

        dialogOperator.SetPlaqueName(character);
        dialogOperator.SetActiveSpeaker(character);
        return PrintText(new string[2] { text_ru, text_en });
    }
    public Task Say(string text_ru, string text_en)
    {
        if (DialogManager.IsCancellationRequested)
            return Task.CompletedTask;

        dialogOperator.SetPlaqueName();
        return PrintText(new string[2] { text_ru, text_en });
    }
    private Task PrintText(string[] text)
    {
        if (DialogManager.IsCancellationRequested)
            return Task.CompletedTask;

        return dialogOperator.PrintText(text);
    }

    public void SceneOn(Sprite sprite)
    {
        dialogOperator.SetBackground(sprite);
    }

    public void SceneOff()
    {
        dialogOperator.OffBackground();
    }
    public void Show(CharacterInformator character, PositionOnTheStage position)
    {
        ViewDirection viewDirection;
        if (position == PositionOnTheStage.Right)
        {
            viewDirection = ViewDirection.Left;
        }
        else
        {
            viewDirection = ViewDirection.Right;
        }
        Show(character, position, viewDirection);
    }

    public void Show(CharacterInformator character, PositionOnTheStage position, ViewDirection viewDirection)
    {
        dialogOperator.AddSpeaker(character);
        dialogOperator.SetPosition(character, position, viewDirection);
    }

    public Task ShowImage(Sprite sprite, string[] text = null)
    {
        return dialogOperator.ShowImage(sprite, text);
    }

    public void HideCharacter(CharacterInformator character)
    {
        dialogOperator.RemoveSpeaker(character);
    }
    public void HideAllSpeakers()
    {
        dialogOperator.ClearAllSpeakers();
    }

    public void Fork(bool soloButton = false)
    {
        if (DialogManager.IsCancellationRequested)
        {
            StopDialogSkip();
            return;
        }

        if (Choices == null || Choices.Count < 1)
        {
            StopDialogSkip();
            dialogOperator.DialogExit();
            return;
        }

        if (!soloButton && Choices.Count == 1)
        {
            Choices[0].StartDialog();
            return;
        }

        StopDialogSkip();
        for (int i = 0; i < Choices.Count; i++)
        {
            //dialogOperator.CreateWayButton(Choices[i]);
        }
    }

    protected void StopDialogSkip()
    {
        if(dialogOperator != null)
            dialogOperator.StopDialogSkip();
    }

    [ContextMenu("Reset name")]
    public void ResetName()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = gameObject.name;
    }
}
