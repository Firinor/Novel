using FirReflection;
using System;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using Scene = StoryInformator.Scene;

public class StoryNode : DialogNode
{
    [SerializeField, Min(1)]
    private int Act;
    [SerializeField, Min(1)]
    private int Scene;

    private Scene scene;
    private int incidentIndex;
    private int incidentCount;

    protected new void Awake()
    {
        base.Awake();
        scene = StoryInformator.instance.GetScene(Act, Scene);
        incidentCount = scene.Count;
    }

    public override void StartDialog()
    {
        base.StartDialog();
        StartScene();
    }

    public async void StartScene()
    {
        incidentIndex = 0;
        for (; incidentIndex < incidentCount;)
        {
            await IncidentAction();
            incidentIndex++;
        }
    }

    private async Task IncidentAction()
    {
        dialogOperator.CleareAll();
        dialogOperator.SetBackground(scene[incidentIndex].Background);
        dialogOperator.SetCharacters(scene[incidentIndex].Characters);

        string function = scene[incidentIndex].Function.ToLower();

        string[] splitFunction = function.Split(':');

        function = splitFunction[0];
        if (string.IsNullOrEmpty(function))
        {
            function = "say";
        }

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
        if (parameters.Length > 1)
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
                    result[i] = scene[incidentIndex].Background;
                    break;
                case "character":
                    result[i] = scene[incidentIndex].Character;
                    break;
                case "emotion":
                    result[i] = scene[incidentIndex].Background;
                    break;
                case "position":
                    result[i] = scene[incidentIndex].Background;
                    break;
                case "viewDirection":
                    result[i] = scene[incidentIndex].Background;
                    break;
                case "text":
                    result[i] = scene[incidentIndex].Text;
                    break;
                default:
                    throw new Exception($"parameterName \"{parameterName}\" not found");
            }
        }
        return result;
    }
}
