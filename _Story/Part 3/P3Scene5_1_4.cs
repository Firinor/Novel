namespace FirGames.StoryPart3
{
    public class P3Scene5_1_4 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Prison);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Поразительно, могущественному некроманту, способному " +
                "повелевать жизнью и смертью, не хватает обычного человеческого внимания.", "");

            Fork();
        }
    }
}
