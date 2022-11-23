namespace FirGames.StoryPart4
{
    public class P4Scene11_b : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Nogation = Characters.Nogation;

            Show(Skull, PositionOnTheStage.Center);
            Show(Nogation, PositionOnTheStage.Right);

            Scene(Backgrounds.Tents);

            await Say(Skull, "Давай еще подумаем. Попытка взлома футляра может привести к уничтожению флакона.", "");

            Fork();
        }
    }
}
