namespace FirGames.StoryPart2
{
    public class P2Scene5_b : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator GnomGuard = storyInformator.GnomGuard;

            Scene(storyInformator.GnomeDoor);

            Show(GnomGuard, PositionOnTheStage.Center);

            await Say(GnomGuard, "��������� ������! ������ �������� ����� �����.", "");

            Fork();
        }
    }
}