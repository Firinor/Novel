using UnityEngine;

public class Scene4 : DialogNode
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

        await Say(Skull, "� � �� ���������� � ����� ������������. � ���� ���� �����:" +
            " ������ ��������� �����-����� ������� ��������� ��� ��������� ����������� ������ ��������� � ��������.", "");

        Fork();
    }
}
