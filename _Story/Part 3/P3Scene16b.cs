namespace FirGames.StoryPart3
{
    public class P3Scene16b : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Не похоже", "");

            Fork();
        }
    }
}
