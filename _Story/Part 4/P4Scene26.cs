namespace FirGames.StoryPart4
{
    public class P4Scene26 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;

            Scene(Backgrounds.OrcEncampment);

            Show(Bathyard, PositionOnTheStage.Right);
            Show(Skull, PositionOnTheStage.Left);

            await Say(Bathyard, "Отец приказал отправляться в путь.", "");

            await Say(Skull, "Мы давно готовы.", "");

            Fork();
        }
    }
}
