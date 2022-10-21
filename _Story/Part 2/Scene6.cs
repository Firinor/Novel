using UnityEngine;

public class Scene6 : DialogNode
{
    [SerializeField]
    private CharacterInformator Skull;
    [SerializeField]
    private CharacterInformator WhiteNecromant;
    [SerializeField]
    private CharacterInformator Yanus;

    [SerializeField]
    private Sprite Island;

    public override async void StartDialog()
    {
        base.StartDialog();

        Scene(Island);

        Show(Skull, PositionOnTheStage.Left);

        await Say(Skull, "���� � ����?! ��� ���� �����, ������� ������?", "");

        Show(WhiteNecromant, PositionOnTheStage.Right);

        await Say(WhiteNecromant, "�����������, ���� ���.", "");

        await Say(Skull, "� �� ���� ��� �� ���� �����������, ����? � ������, " +
            "��������� �� ���-������ ����������� ��������� �������� ������� �� ���� ������.", "");

        Hide(WhiteNecromant);
        Show(Yanus, PositionOnTheStage.Right);

        await Say(Yanus, "������� ����� � ������ ��� ��� ������� ������. " +
            "���� ������� ������� ���������� ������ � ������ �� �������� ������ ���� ���-�����.", "");

        await Say(Yanus, "� ���������� ������.", "");

        await Say(Skull, "������ ��� ������ � �������� ������� ����� �������.", "");

        await Say(Skull, "���� �� ����, ��� �� ��� ��� ��� ������ � ����� � ��� �� ��������, " +
            "���� �������� ������������� �� ����������. ����� ���������?", "");

        await Say(Yanus, "���� ���, ���� ����� �� ����� ��������� ������� �� ����.", "");

        await Say(Yanus, "���� ����, ����������� ������ ���������, ��� ���� ����������� �������, " +
            "����� ����� ��������� ������.", "");

        await Say(Yanus, "��� ������ �������� � ������ ������� �������� �� ������ �������.", "");

        await Say(Skull, "��� ��� �������� � ����� ��������� ������������ ��������� ���������.", "");

        await Say(Yanus, "��� ������� ����������� ������. " +
            "������� ������� ������� � ������ ������������ ��������� ���� ������ �������������� �������������� ���.", "");

        Fork();
    }
}
