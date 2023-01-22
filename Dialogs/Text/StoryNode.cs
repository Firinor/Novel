using FirReflection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using Episode = StoryInformator.Episode;

public class StoryNode : DialogNode
{
    [SerializeField, Min(1)]
    private int Act;
    [SerializeField, Min(1)]
    private int Scene;

    private Episode episode;
    private int incidentIndex;
    private int incidentCount;

    protected new void Awake()
    {
        base.Awake();
        episode = StoryInformator.instance.GetScene(Act, Scene);
        incidentCount = episode.Count;
    }

    public override void StartDialog()
    {
        base.StartDialog();
        StartScene();
    }

    public async void StartScene()
    {
        StopDialogSkip();

        incidentIndex = 0;
        for (; incidentIndex < incidentCount;)
        {
            await IncidentAction();
            incidentIndex++;
        }

        Fork();
    }

    private async Task IncidentAction()
    {
        dialogOperator.CleareAll();
        dialogOperator.SetBackground(episode[incidentIndex].Background);
        dialogOperator.SetCharacters(episode[incidentIndex].Characters);

        string function = episode[incidentIndex].Function.ToLower();

        string[] splitFunction = function.Split(':');

        //Trying different algorithms, I came to the conclusion that we will always call only the "say" method
        #region Non-removable garbage
        //function = splitFunction[0];
        //if (string.IsNullOrEmpty(function))
        //{
        //    function = "say";
        //}
        #endregion
        function = "say";

        string additionalParameter = "";

        if (splitFunction.Length > 1)
        {
            additionalParameter = splitFunction[1];
        }

        MethodInfo[] methods = typeof(DialogOperator).GetMethods();
        //{
        //CleareAll
        //ShowImage
        //ShowText
        //SetBackground
        //ShowCharacter
        //HideCharacter
        //HideAllCharacters
        //Say
        //SayByName:Name
        //Choise:Number
        //}

        MethodInfo method = null;
        object[] _params = null;

        foreach (MethodInfo m in methods)
        {
            if(m.Name.ToLower() == function)
            {
                method = m;
                _params = GetParams(m, additionalParameter);
                break;
            }
        }

        if(method == null)
        {
            throw new Exception($"Function \"{function}\" not found");
        }

        await ReflectionMethods.InvokeAsync(method, dialogOperator, _params);
    }

    private object[] GetParams(MethodInfo method, string additionalParameter = "")
    {
        ParameterInfo[] parameters = method.GetParameters();
        //{
        //string nameOnPlague
        //Sprite background
        //CharacterInformator character
        //CharacterEmotion emotion
        //PositionOnTheStage position
        //ViewDirection viewDirection
        //string[] text
        //}

        object[] result = null;
        if (parameters.Length > 0)
        {
            result = new object[method.GetParameters().Length];
        }

        for(int i = 0; i < parameters.Length; i++)
        {
            string parameterName = parameters[i].Name;
            switch (parameterName){
                case "nameOnPlague":
                    result[i] = additionalParameter;
                    break;
                case "background":
                    result[i] = episode[incidentIndex].Background;
                    break;
                case "character":
                    result[i] = episode[incidentIndex].Character;
                    break;
                case "emotion":
                    result[i] = episode[incidentIndex].Background;
                    break;
                case "position":
                    result[i] = episode[incidentIndex].Background;
                    break;
                case "viewDirection":
                    result[i] = episode[incidentIndex].Background;
                    break;
                case "text":
                    result[i] = episode[incidentIndex].Text;
                    break;
                default:
                    throw new Exception($"parameterName \"{parameterName}\" not found");
            }
        }
        return result;
    }

    public void Fork()
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

        if(episode != null && episode.Choices != null && episode.Choices.Count > 0)
        {
            StopDialogSkip();
            for (int i = 0; i < episode.Choices.Count; i++)
            {
                dialogOperator.CreateWayButton(Choices[i], episode.Choices[i]);
            }
            return;
        }

        Choices[0].StartDialog();
    }

    [ContextMenu("Reset game object")]
    public override void ResetGameObject()
    {
        base.ResetGameObject();
        episode = FindObjectOfType<StoryInformator>().GetScene(Act, Scene);
        //Choices = new List<DialogNode>();
        for(int i = 0; i < episode.Choices.Count - Choices.Count; i++)
        {
            Choices.Add(null);
        }
    }
}
