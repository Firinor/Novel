namespace FirGames.StoryPart3
{
    public class P3Scene5_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.FirePlace);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "� ���� �����, ��� ���� � ��� ������������� �������� ��" +
                " ����� ������ ����� ���� ����������� ��������.", "");

            await Say(Skull, "� ������ ������ �� �����, ������ ��� ���� ������" +
                " ��������� � ��������� ������ �� ��������� � �������� �����������.", "");

            await Say(Skull, "���� ������. ��� ������ ����� �������� ���� � �������� ����������," +
                " �� ���������� � ��������� ���������� � ����� ���-�����.", "");

            Fork();
        }
    }
}
