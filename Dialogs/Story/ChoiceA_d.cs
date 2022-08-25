using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceA_d : DialogNode
{
    [SerializeField]
    private CharacterInformator Artur;

    [SerializeField]
    private Sprite scene;


    public override void StartDialog()
    {
        CleareAll();

        Scene(scene);
        Show(Artur, PositionOnTheStage.Center);

        Say(Artur, "Был выбран вариант \"А\"");

        Fork();
    }

}
