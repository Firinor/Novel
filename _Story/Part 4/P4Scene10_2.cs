namespace FirGames.StoryPart4
{
    public class P4Scene10_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Show(Skull, PositionOnTheStage.Center);

            Scene(Backgrounds.Tents);

            await Say(Skull, "Открывать портал мы не будем. Идите и попытайтесь выжить на просторах Карпатии.", "");
            await Say(Skull, "Сейчас вы помилованы, но не надейтесь на подобное снисхождение во второй раз.", "");

            Fork();
        }
    }
}
