using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public enum PositionOnTheStage { Left, Center, Right, OffScene }

public abstract class DialogNode : MonoBehaviour
{
    [SerializeField]
    private string[] Header = new string[2] { "������� ��������", "english name" };
    [SerializeField]
    private string DescriptionOfSelection;
    [SerializeField]
    private DialogNode[] Choices;
    private DialogOperator dialogOperator;

    public string Description { get { return DescriptionOfSelection; } }

    void Awake()
    {
        dialogOperator = DialogOperator.instance;
    }
    public string GetHeader()
    {
        return Header[(int)PlayerManager.Language];
    }

    public virtual void StartDialog()
    {
        DialogManager.ActivateDialog();
        CleareAll();
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

    public Task Say(CharacterInformator character, string text)
    {
        if (DialogManager.IsCancellationRequested)
            return Task.CompletedTask;

        dialogOperator.SetPlaqueName(character);
        dialogOperator.SetActiveSpeaker(character);
        return PrintText(text);
    }
    public Task Say(string text)
    {
        if (DialogManager.IsCancellationRequested)
            return Task.CompletedTask;

        dialogOperator.SetPlaqueName();
        return PrintText(text);
    }
    private Task PrintText(string text)
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
        dialogOperator.AddSpeaker(character);
        dialogOperator.SetPosition(character, position);
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
        if (Choices == null || Choices.Length < 1)
        {
            dialogOperator.EndOfDialog();
            return;
        }

        if (Choices.Length == 1)
        {
            Choices[0].StartDialog();
            return;
        }

        for(int i = 0; i < Choices.Length; i++)
        {
            dialogOperator.CreateWayButton(Choices[i]);
        }
    }
}
