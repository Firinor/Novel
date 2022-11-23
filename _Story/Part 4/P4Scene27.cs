namespace FirGames.StoryPart4
{
    public class P4Scene27 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;

            Scene(Backgrounds.Desert);

            Show(Bathyard, PositionOnTheStage.Right);
            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Батярд, по нашим расчетам Ногаций давно должен был передать Хурге приказ вождя.", "");
            await Say(Skull, "Почему же мы до сих пор не встретили по дороге возвращающихся воинов?" +
                " Войско орков не иголка, мы бы заметили.", "");

            await Say(Bathyard, "Верно говоришь. Не к добру, что темный шаман медлит.", "");

            await Say(Skull, "Есть предложение сначала заглянуть в лагерь Хурги и разведать обстановку," +
                " а уже потом отправиться к герцогу Аргузу.", "");
            await Say(Skull, "Архимагистр наложит заклинение искажение пространства, чтобы мы смогли" +
                " подобраться к Хурге незамеченными, а наши воины пока отдохнут.", "");

            await Say(Bathyard, "Мне нравятся опасные затеи! Давай свое заклинание.", "");

            Fork();
        }
    }
}
