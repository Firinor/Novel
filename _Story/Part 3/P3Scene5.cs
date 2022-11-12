namespace FirGames.StoryPart3
{
    public class P3Scene5 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.FirePlace);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Знания эльфов могут стать серьезным аргументов в борьбе за пост архимагистра," +
                " но можно ли доверять Тииру? Возможно будет лучше сначала посоветоваться с Янусом?", "");

            Fork();
        }
    }
}
