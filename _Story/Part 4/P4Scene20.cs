namespace FirGames.StoryPart4
{
    public class P4Scene20 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.CommanderInChiefsTent);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Великолепно! Мы в безопасности до самого стойбища Вацелы.", "");

            Fork();
        }
    }
}
