namespace FirGames.StoryPart3
{
    public class P3Scene1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.InessaRoom);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Поздравления сыпятся со всех сторон: коллеги по ордену, лорд Карлос," +
                " Карим - все прислали письма. А вот самое интересное с печатью королевы Эрмингарды.", "");

            await Say(Skull, "Она выражает благодарность и соболезнования." +
                " Пишет, что покойный архимагистр воспитал достойного ребенка." +
                " Звучит мило, но, как говорит Карим, чем шире улыбка, тем острее нож.", "");

            Fork();
        }
    }
}
