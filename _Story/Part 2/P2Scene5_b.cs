namespace FirGames.StoryPart2
{
    public class P2Scene5_b : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator GnomGuard = Characters.GnomGuard;

            Scene(Backgrounds.GnomeDoor);

            Show(GnomGuard, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(GnomGuard, "????????? ??????! ?????? ???????? ????? ?????.", "");

            Fork();
        }
    }
}