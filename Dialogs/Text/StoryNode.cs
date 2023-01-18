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
        incidentCount = scene.Length;
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
        string function = scene[incidentIndex].Function.ToLower();

        string[] splitFunction = function.Split(':');

        function = splitFunction[0];

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
        //SayByName:Имя
        //Choise:Номер
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
            result[i] = ;
        }
        

        ////CharacterInformator Skull = Characters.Skull;
        //CharacterInformator Archmagister = Characters.Cristopher;
        ////Scene(Backgrounds.Lab);
        //ShowCharacter(Archmagister, PositionOnTheStage.Right, ViewDirection.Left);
        //await Say(Archmagister, "Дитя мое, настал день твоего экзамена." +
        //    " Вечером ты уже будешь признанным магистром и мы сможем отпраздновать.", "");
        //await Say(Archmagister, "Принимать экзамен будет наимудрейший беспристрастный основатель нашего ордена," +
        //    " лучше других знающий к каким последствиям приводит риск в нашем деле.", "");

        return result;
    }
}
