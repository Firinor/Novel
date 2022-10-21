using UnityEngine;

public class Scene2 : DialogNode
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

        await Say(Skull, "Очень странно, что архимагистр ордена Познающих сам пошел открывать портал для какого-то каравана," +
            " когда есть целая команда таких как ты. ", "");

        await Say(Skull, "Хотя в наше неспокойное время, после смерти короля, никому нельзя доверять." +
            " Для начала проверим базовые знания.", "");

        await Say(Skull, "Создай мне сферу силы стандартного радиуса огненно-рыжего цвета с алыми вкраплениями.", "");

        Fork();
    }
}
