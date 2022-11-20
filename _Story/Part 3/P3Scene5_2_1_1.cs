namespace FirGames.StoryPart3
{
    public class P3Scene5_2_1_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.BeginOfElvenForest);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Безусловно. Эльфы живут долго, но они не бессмертны.", "");

            await Say(Skull, "Момент, когда магистры начали держаться за свои секреты," +
                " а молодые маги прекратили задавать вопрос “почему” и стали просто подставлять" +
                " цифры в формулы ознаменовал собой начало конца для страны эльфов.", "");

            await Say(Skull, "Тиир не такой, он не только ищет способы чего-то достичь" +
                " и пытается проникнуть в суть вещей.", "");

            Fork();
        }
    }
}
