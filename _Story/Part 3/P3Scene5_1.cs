namespace FirGames.StoryPart3
{
    public class P3Scene5_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.FirePlace);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Я тоже думаю, что Янус с его нетривиальным взглядом на" +
                " бытие должен знать всех сумасшедших Алфараха.", "");

            await Say(Skull, "И далеко ходить не нужно, потому что Янус сейчас" +
                " находится в городской тюрьме по обвинению в убийстве губернатора.", "");

            await Say(Skull, "Идем скорее. Как только Янусу надоедят игры с системой правосудия," +
                " он отправится в очередное странствие и потом ищи-свищи.", "");

            Fork();
        }
    }
}
