using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using FirGames;

public enum PositionOnTheStage { Left, Center, Right, OffScene }
public enum ViewDirection { Right = 1, Left = -1 }

public abstract class DialogNode : MonoBehaviour
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string[] Header = new string[2] { "русское название", "english name" };
    [SerializeField]
    private string DescriptionOfSelection;
    [SerializeField]
    private List<DialogNode> Choices;
    private DialogOperator dialogOperator;
    protected StoryInformator storyInformator;

    public int ID { get { return id; } }
    public string Description { get { return DescriptionOfSelection; } }

    protected void Awake()
    {
        storyInformator = StoryInformator.instance;
        dialogOperator = DialogOperator.instance;
        GetComponent<Button>().onClick.AddListener(StartDialog);
    }
    public void AddChoice(DialogNode dialogNode)
    {
        if(Choices == null || Choices.Count == 0)
        {
            Choices = new List<DialogNode>();
        }

        Choices.Add(dialogNode);
    }
    public string GetHeader()
    {
        return Header[(int)PlayerManager.Language];
    }
    public virtual void StartDialog()
    {
        DialogManager.ActivateDialog(gameObject.GetComponent<RectTransform>().anchoredPosition.x);
        CleareAll();
        dialogOperator.SetSceneName(name);
    }

    public void StartDialog(int index)
    {
        if(Choices != null && (Choices.Count - 1) >= index)
            Choices[index]?.StartDialog();
    }

    public void CleareAll()
    {
        SceneOff();
        HideAll();
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
    public void Show(CharacterInformator character, PositionOnTheStage position,
        ViewDirection viewDirection = ViewDirection.Right)
    {
        dialogOperator.AddSpeaker(character);
        dialogOperator.SetPosition(character, position, viewDirection);
    }

    public void Hide(CharacterInformator character)
    {
        dialogOperator.RemoveSpeaker(character);
    }
    public void HideAll()
    {
        dialogOperator.ClearAllSpeakers();
    }

    public void Fork()
    {
        if (DialogManager.IsCancellationRequested)
        {
            DialogOperator.skipText = false;
            return;
        }

        if (Choices == null || Choices.Count < 1)
        {
            DialogOperator.skipText = false;
            dialogOperator.DialogExit();
            return;
        }

        if (Choices.Count == 1)
        {
            Choices[0].StartDialog();
            return;
        }

        DialogOperator.skipText = false;
        for (int i = 0; i < Choices.Count; i++)
        {
            dialogOperator.CreateWayButton(Choices[i]);
        }
    }
}
