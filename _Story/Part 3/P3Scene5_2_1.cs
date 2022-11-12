namespace FirGames.StoryPart3
{
    public class P3Scene5_2_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.BeginOfElvenForest);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "����� ���� ���������� �����, ��, ��� ��, ��� �� ��� ��������." +
                " ����������� �������, ��������� ��������, ���� �������, �� �� ���� �� ���� �������������, " +
                "������ ������ ���� ��������.", "");

            await Say(Skull, "����� �� ����, ��� ���� ������� ��� ����������� ������ ����� �� �������, " +
                "��� ��� ��� � �����. ��� �������, ��� ��������� �������� ������ ���������� ����?", "");

            Fork();
        }
    }
}
