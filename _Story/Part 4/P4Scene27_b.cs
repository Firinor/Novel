namespace FirGames.StoryPart4
{
    public class P4Scene27_b : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.Desert);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Сосредоточься! Ты же архимагистр.", "");

            Fork();
        }
    }
}
