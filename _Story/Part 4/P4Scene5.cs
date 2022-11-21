namespace FirGames.StoryPart4
{
    public class P4Scene5 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Ermingarda = Characters.Ermingarda;

            Scene(Backgrounds.ThroneRoom);

            Show(Skull, PositionOnTheStage.Left);
            Show(Ermingarda, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Ermingarda, "Мы приветствуем архимагистра, инженера порталов, о котором говорит вся столица.", "");

            await Say(Skull, "Наше почтение, Ваше Величество.", "");

            await Say(Ermingarda, "Новый портал помог решить транспортную проблему" +
                " в столице и мы желаем повторить удачный опыт на приграничных землях.", "");

            await Say(Skull, "То есть построить новый портал в Карпатии?", "");

            await Say(Ermingarda, "В наше смутное время почти никому нельзя доверять." +
                " Мы желаем, чтобы вы лично отправились в Карпатию.", "");
            await Say(Ermingarda, "Узнайте, почему так долго нет вестей от моего деверя герцога Аргуза," +
                " который мужественно защищает нашу землю от нашествия орков.", "");

            await Say(Skull, "Члены ордена Познающих готовы служить Алфараху, но," +
                " при всем уважении, возможно, есть более опытные воины?", "");

            await Say(Ermingarda, "В приграничных землях важно не только воинское искусство, но и ум." +
                " Двадцать моих лучших солдат будут обеспечивать вашу безопасность.", "");
            await Say(Ermingarda, "Приказываю отправляться как можно скорее, потому что я очень волнуюсь за деверя.", "");

            await Say(Skull, "Как прикажите.", "");

            await ShowImage(SpecialImages.TwoDaysHavePassed);

            Fork();
        }
    }
}
