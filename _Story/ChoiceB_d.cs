using UnityEngine;

public class ChoiceB_d : DialogNode
{
    [SerializeField]
    private CharacterInformator Artur;

    [SerializeField]
    private Sprite scene;

    public override async void StartDialog()
    {
        base.StartDialog();

        Scene(scene);
        Show(Artur, PositionOnTheStage.Center);

        await Say(Artur, "Был выбран вариант \"Б\"");

        Fork();
    }

}
