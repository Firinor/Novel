using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using static StoryInformator;

public enum PositionOnTheStage { OffScene, Left, Center, Right}
public enum DialogProgressStatus { Open, Closed, Hiden }

public class DialogNode : MonoBehaviour
{
    [SerializeField]
    private string[] Header = new string[2] { "русское название", "english name" };
    [SerializeField]
    private List<DialogNode> Choices;
    private DialogProgressStatus dialogProgressStatus = DialogProgressStatus.Hiden;

    protected DialogOperator dialogOperator;
    protected Characters Characters;
    protected Backgrounds Backgrounds;

    protected void Awake()
    {
        StoryInformator storyInformator = StoryInformator.instance;
        Characters = storyInformator.characters;
        Backgrounds = storyInformator.backgrounds;
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
    }
    public void StartDialog(int index)
    {
        if(Choices != null && Choices.Count > index)
            Choices[index]?.StartDialog();
    }

    public void CleareAll()
    {
        OffBackground();
        HideAllCharacters();
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

    public void SetBackground(Sprite sprite)
    {
        dialogOperator.SetBackground(sprite);
    }

    public void OffBackground()
    {
        dialogOperator.OffBackground();
    }
    public void ShowCharacter(CharacterInformator character, PositionOnTheStage position)
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
        ShowCharacter(character, position, viewDirection);
    }

    public void ShowCharacter(CharacterInformator character, PositionOnTheStage position, ViewDirection viewDirection)
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
    public void HideAllCharacters()
    {
        dialogOperator.ClearAllCharacters();
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
