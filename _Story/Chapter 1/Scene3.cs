using UnityEngine;

public class Scene3 : DialogNode
{
    [SerializeField]
    private CharacterInformator Skull;

    [SerializeField]
    private Sprite Island;

    public override async void StartDialog()
    {
        base.StartDialog();

        Scene(Island);

        Show(Skull, PositionOnTheStage.Center);

        await Say(Skull, "“ы отличный хранитель знаний," +
            " но все же будь осторожнее со своей безумной теорией о том, что портала ”шедших можно воссоздать.", "");

        await Say(Skull, "ћаги ордена ѕознающих могут открывать древние порталы, " +
            "но построить работающий портал еще никому не удавалось. “еперь проверим знани€ алхимии.", "");

        Fork();
    }
}
