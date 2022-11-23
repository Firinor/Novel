namespace FirGames.StoryPart4
{
    public class P4Scene24 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;

            Scene(Backgrounds.OrcEncampment);

            Show(Bathyard, PositionOnTheStage.Right);
            Show(Skull, PositionOnTheStage.Left);

            await Say(Bathyard, "Так держать! В тебе есть что-то от орка.", "");

            await Say(Skull, "Хурга, очевидно, уважаемый воин.", "");

            await Say(Bathyard, "Хурга посвящен в магию, неизвестную оркам, " +
                "но у него две головы и властолюбивое сердце.", "");

            Fork();
        }
    }
}
