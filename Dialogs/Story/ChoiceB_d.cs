using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceB_d : DialogNode
{
    [SerializeField]
    private CharacterInformator Artur;

    [SerializeField]
    private Sprite scene;

    public override void StartDialog()
    {
        base.StartDialog();

        Scene(scene);
        Show(Artur, PositionOnTheStage.Center);

        Say(Artur, "Был выбран вариант \"Б\"");

        Fork();
    }

}
