using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public enum PositionOnTheStage { Left, Center, Right, OffScene }
public enum ViewDirection { Right = 1, Left = -1 }

public abstract class DialogNode : MonoBehaviour
{
    [SerializeField]
    private string[] Header = new string[2] { "русское название", "english name" };
    [SerializeField]
    private string DescriptionOfSelection;
    [SerializeField]
    private List<DialogNode> Choices;
    

    private DialogOperator dialogOperator;
    protected StoryInformator.Characters Characters;
    protected StoryInformator.Backgrounds Backgrounds;
    protected StoryInformator.SpecialImages SpecialImages;

    public string Description { get { return DescriptionOfSelection; } }

    protected void Awake()
    {
        StoryInformator storyInformator = StoryInformator.instance;
        Characters = storyInformator.characters;
        Backgrounds = storyInformator.backgrounds;
        SpecialImages = storyInformator.specialImages;
        dialogOperator = DialogOperator.instance;
        GetComponent<Button>().onClick.AddListener(StartDialog);
    }
    public void SetChoice(DialogNode dialogNode)
    {
        if (dialogNode == null)
            return;

        Choices = new List<DialogNode>();
        Choices.Add(dialogNode);
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
        SceneOff();
        HideAllSpeakers();
        HideAllWays();
        //music off
    }

    private void HideAllWays()
    {
        dialogOperator.HideAllWays();
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

    public void Scene(Sprite sprite)
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

    public Task ShowImage(Sprite sprite)
    {
        return dialogOperator.ShowImage(sprite);
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
            dialogOperator.CreateWayButton(Choices[i]);
        }
    }

    protected void StopDialogSkip()
    {
        if(dialogOperator != null)
            dialogOperator.StopDialogSkip();
    }
}
