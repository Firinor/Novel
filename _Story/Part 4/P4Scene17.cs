namespace FirGames.StoryPart4
{
    public class P4Scene17 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Arguz = Characters.Arguz;

            Scene(Backgrounds.CommanderInChiefsTent);

            Show(Skull, PositionOnTheStage.Left);
            Show(Arguz, PositionOnTheStage.Right);

            await Say(Skull, "Ваша Милость, наконец-то! Мы уже начали беспокоиться.", "");

            await Say(Arguz, "Орки ходят на войну не только за подвигами, но и за добычей." +
                " Мы использовали тактику выжженной земли и Хурге теперь нечем платить орде.", "");
            await Say(Arguz, "Вацела отправил золото, чтобы избежать бунта, но долго терпеть" +
                " убыточную войну он не станет.", "");

            await Say(Skull, "Воспользуемся этим. Мы пойдем на переговоры к вождю и предложим ему дань.", "");

            await Say(Arguz, "Идти к Вацеле без даров самоубийство. Я прикажу выковать красивый меч.", "");

            await Say(Skull, "При всем уважении, мечи дарит каждый первый. " +
                "Предлагаю подарить древний фолиант, описывающий славную историю предков Вацелы.", "");

            await Say(Arguz, "Где его взять?", "");

            await Say(Skull, "Сами сделаем. Состарить вещь не так сложно.", "");

            await Say(Arguz, "Мне идея нравится. Немедленно приступим к изготовлению фолианта.", "");

            Fork();
        }
    }
}
