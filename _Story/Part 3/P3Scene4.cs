namespace FirGames.StoryPart3
{
    public class P3Scene4 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Tiir = Characters.Tiir;

            Scene(Backgrounds.Fun);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "��� ��� ��������?! ������ � ��������� ������ � ��������?! � ��� ���?!", "");

            Show(Tiir, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Tiir, "�� ����� �����������. ���, ���� �� ������� ������," +
                " � ��������� ��������� � ��������� ������� ����������.", "");

            await Say(Skull, "�� ��� �����?", "");

            await Say(Tiir, "��� ��� ����, � �������, ����� ������ ������.", "");

            await Say(Skull, "�������? ����� �������.", "");

            await Say(Tiir, "� ������� ����� ���������� ����� ������ ���� ������.", "");

            await Say(Tiir, "������ ����� ��� ������ ������ � ��������� ����������� � ������� �������," +
                " �� �� �������� ��� ��������.", "");

            await Say(Tiir, "�� �������, ����� ���������, ���� �������� ���� �� �����.", "");

            await Say(Skull, "��� ��� �����, �������� �������?", "");

            await Say(Tiir, "���� ������ ����, ���������� ����� ������," +
                " �� � �� ����� ��������� ���� ������ �����, ��� ����� ����� ����� ���.", "");

            await Say(Tiir, "����� ������, ��� ������������� �������� ������ ����� ������ ������������. " +
                "���� ���������, ������� � ��� ��������� �����. ��� �����.", "");

            await Say(Skull, "�� ��������.", "");

            await Say(Tiir, "����������. �������� ����� ����� ��������� ��� �������.", "");

            await Say(Tiir, "������ ������������, ��������� ������ ������� ������ ����," +
                " ��������� � ��������� ��� ��������� � �������� �����. �� �� ��������, ��� ��� ���� ��.", "");

            await Say(Skull, "���������. ��� �� ��������?", "");

            Fork();
        }
    }
}
