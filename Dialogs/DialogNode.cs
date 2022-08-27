using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;

public enum PositionOnTheStage { Left, Center, Right, OffScene }

public abstract class DialogNode : MonoBehaviour
{
    [SerializeField]
    private DialogNode[] Choices;
    [SerializeField]
    private string DescriptionOfSelection;
    private DialogOperator dialogOperator;

    void Awake()
    {
        dialogOperator = DialogOperator.instance;
    }
    public virtual string GetHeader()
    {
        return "ERROR!!!";
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
        //music off
    }
    public Task Say(CharacterInformator character, string text)
    {
        dialogOperator.SetPlaqueName(character);
        dialogOperator.SetActiveSpeaker(character);
        return PrintText(text);
    }
    public Task Say(string text)
    {
        dialogOperator.SetPlaqueName();
        return PrintText(text);
    }
    private Task PrintText(string text)
    {
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
        dialogOperator.AddSpeaker(character, position);
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

        }

        if (Choices.Length == 1)
        {

        }

        for(int i = 0; i < Choices.Length; i++)
        {

        }
    }
}
