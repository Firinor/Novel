namespace FirGames.StoryPart1
{
    public class P1Scene6 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Yanus = Characters.Yanus;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "���� � ����?! ��� ���� �����, ������� ������?", "");

            Show(Yanus, PositionOnTheStage.Center);

            await SayByName(Yanus, "����� ���������", "White necromant",
                "�����������, ���� ���.", "");

            await Say(Skull, "� �� ���� ��� �� ���� �����������, ����? � ������, " +
                "��������� �� ���-������ ����������� ��������� �������� ������� �� ���� ������.", "");

            Show(Yanus, PositionOnTheStage.Right, ViewDirection.Left);

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
}