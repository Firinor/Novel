namespace FirGames.StoryPart3
{
    public class P3Scene13b : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Voice = storyInformator.Voice;

            Scene(storyInformator.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Voice, "А вот и не угадали!", "");

            Fork();
        }
    }
}
