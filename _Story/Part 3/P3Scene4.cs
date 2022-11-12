namespace FirGames.StoryPart3
{
    public class P3Scene4 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Tiir = storyInformator.Tiir;

            Scene(storyInformator.Fun);

            Show(Skull, PositionOnTheStage.Right);

            await Say(Skull, "��� ��� ��������?! ������ � ��������� ������ � ��������?! � ��� ���?!", "");

            Show(Tiir, PositionOnTheStage.Left, ViewDirection.Left);

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
