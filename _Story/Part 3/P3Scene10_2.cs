namespace FirGames.StoryPart3
{
    public class P3Scene10_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.PortalOn);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "� ��� ��� ������. ���� ������ �������� ����� ������������," +
                " ���� ��� �����������. ���� ����� - ��� �������, ���� ��������� � ������� - ��� ��������.", "");

            await Say(Skull, "������ ��������� � ����� ������������. ���� ������. ���, ���, ���.", "");

            Fork();
        }
    }
}
