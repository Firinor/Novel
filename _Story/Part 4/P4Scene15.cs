namespace FirGames.StoryPart4
{
    public class P4Scene15 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.Desert);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Карпатия всегда была опасным местом. " +
                "Десять лет назад во время очередного набега погиб старший сын покойного короля.", "");
            await Say(Skull, "Помню, у парня был редкий талант к магии иллюзий и горячая голова.", "");
            await Say(Skull, "От горя вскоре умерла его мать, первая королева, а ее место заняла Эрмингарда." +
                " Смотри, вот и лагерь герцога.", "");

            Fork();
        }
    }
}
