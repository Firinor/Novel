namespace FirGames.StoryPart4
{
    public class P4Scene22 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;
            CharacterInformator Nogation = Characters.Nogation;
            CharacterInformator Vacela = Characters.Vacela;

            Scene(Backgrounds.OrcCommanderInChiefsTent);

            Show(Vacela, PositionOnTheStage.Center, ViewDirection.Left);
            Show(Skull, PositionOnTheStage.Left);
            Show(Bathyard, PositionOnTheStage.Right);
            Show(Nogation, PositionOnTheStage.Right);

            await Say(Vacela, "Посольство? Пришли пополнить наш склад оружия?", "");

            await Say(Skull, "Преклоняемся перед мудростью и могуществом великого вождя Вацелы." +
                " Примите в качестве дара фолиант о подвигах ваших предков.", "");

            await Say(Vacela, "Что-то новенькое. Покажите. Где вы это взяли?", "");

            await Say(Skull, "Фолиант был найден нашими историками. Мы сразу поспешили вернуть его истинному владельцу.", "");

            await Say(Vacela, "Аргуз умеет выбирать послов. Что он хочет?", "");

            await Say(Skull, "Герцог Аргуз полагает, что у вас есть более достойные враги, чем он.", "");

            await Say(Vacela, "Правильно полагает. Аргуз шакал среди львов.", "");

            await Say(Skull, "Герцог желает заключить мир.", "");

            await Say(Vacela, "Что он предлагает?", "");

            await Say(Skull, "Вот, взгляните на черновик соглашения, великий вождь.", "");

            await Say(Vacela, "Аргуз меняет кровь на золото. Вполне в его духе.", "");

            Show(Vacela, PositionOnTheStage.Center, ViewDirection.Right);
            await Say(Vacela, "Ногаций, отправляйся к Хурге и передай, что я приказываю возвращаться в стойбище.", "");
            await Say(Vacela, "Батярд, ты отправишься за золотом.", "");

            await Say(Skull, "Можем выдвинуться утром.", "");

            Show(Vacela, PositionOnTheStage.Center, ViewDirection.Left);
            await Say(Vacela, "Желтый  металл подождет. Будите гостями на моем пиру" +
                " в честь церемонии взросления наших детей.", "");

            await Say(Skull, "Почтем за честь.", "");

            await ShowImage(Backgrounds.OrcParty);

            Fork();
        }
    }
}
