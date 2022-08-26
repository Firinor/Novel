using System;
using System.Threading.Tasks;
using UnityEngine;

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

    public Task PrintText(string text)
    {
        return dialogOperator.PrintText(text);
    }

    public void Scene(Sprite sprite)
    {
        dialogOperator.SetBackground(sprite);
    }

    public void SceneOff()
    {

    }

    public Task Say(CharacterInformator character, string text)
    {
        dialogOperator.SetActiveSpeaker(character);
        return PrintText(text);
    }

    public void Show(CharacterInformator character, PositionOnTheStage position)
    {
        
    }

    public void Hide(CharacterInformator character)
    {
        
    }
    public void HideAll()
    {

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
