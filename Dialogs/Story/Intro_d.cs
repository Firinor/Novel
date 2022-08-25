using System;
using UnityEngine;

public class Intro_d : DialogNode
{
    [SerializeField]
    private string[] Header = new
        string[2] { "Начать", "Start" };

    [SerializeField]
    private CharacterInformator Speaker;
    [SerializeField]
    private CharacterInformator Artur;
    [SerializeField]
    private CharacterInformator Knight;
    [SerializeField]
    private CharacterInformator Olivia;
    [SerializeField]
    private CharacterInformator Orc;
    [SerializeField]
    private CharacterInformator Mark;
    [SerializeField]
    private CharacterInformator Uysyf;

    [SerializeField]
    private Sprite Lab;
    [SerializeField]
    private Sprite Island;
    [SerializeField]
    private Sprite Tavern;

    public override string GetHeader()
    {
        return Header[(int)PlayerManager.Language];
    }

    public override void StartDialog()
    {
        NoName("");

        NoName("...");

        NoName("Это базовая пустая сцена!");

        Say(Speaker, "Привет!");

        Say(Speaker, "Так говорит персонаж без присутствия на сцене.");

        Show(Uysyf, PositionOnTheStage.Center);

        Say(Uysyf, "Так говорит персонаж появившийся по середине сцены.");

        Show(Artur, PositionOnTheStage.Center);
        Show(Knight, PositionOnTheStage.Left);
        Show(Olivia, PositionOnTheStage.Left);
        Show(Orc, PositionOnTheStage.Right);
        Show(Mark, PositionOnTheStage.Right);

        Say(Uysyf, "Одновременно на сцене может быть не более 6 персонажей. Персонажи не могут повторяться.");
        Say(Olivia, "Говорящий персонаж выделяется на фоне других.");

        Scene(Lab);
        Say(Olivia, "Вот так выглядит задник.");

        SceneOff();
        Say(Olivia, "Задники и персонажей можно отключать.");

        Scene(Island);

        Hide(Artur);
        Hide(Knight);
        Hide(Olivia);
        Hide(Orc);

        Say(Uysyf, "Задники могут меняться");

        Scene(Tavern);

        Say(Olivia, "Персонажи умеют говорить из-за сцены.");

        Show(Mark, PositionOnTheStage.Left);

        NoName("Персонажи умеют перемещаться по сцене. Марк переместился с правой стороны экрана на левую.");

        Say(Mark, "Марк это я)");

        Say(Mark, "Есть возможность выбрать из нескольких вариантов ответов:");

        Fork();
    }
}
