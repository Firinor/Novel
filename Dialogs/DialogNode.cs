using System;
using UnityEngine;

public enum PositionOnTheStage { Left, Center, Right, OffScene, Off }

public abstract class DialogNode : MonoBehaviour
{
    [SerializeField]
    private DialogNode[] Choices;
    [SerializeField]
    private string DescriptionOfSelection;


    public virtual string GetHeader()
    {
        return "ERROR!!!";
    }

    public virtual void StartDialog()
    {
        CleareAll();
    }

    public void CleareAll()
    {
        SceneOff();
        HideAll();
        //music off
    }

    public void NoName(string text)
    {

    }

    public void Scene(Sprite sprite)
    {

    }

    public void SceneOff()
    {

    }

    public void Say(CharacterInformator character, string text)
    {

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
