namespace FirGames.StoryPart3
{
    public class P3Scene6b : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.ElvenHut);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Не открывается.", "");

            Fork();
        }
    }
}
