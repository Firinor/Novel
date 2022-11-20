namespace FirGames.StoryPart3
{
    public class P3Scene8 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Tiir = Characters.Tiir;

            Scene(Backgrounds.TiirRoom);

            Show(Skull, PositionOnTheStage.Left);
            Show(Tiir, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Tiir, "Здесь все что вы просили. Можем отправляться в путь." +
                " Ваш гном с радостью предоставил флюорит.", "");

            await Say(Skull, "Вы что, его отравили?", "");

            await Say(Tiir, "Нет, но я убедил его что он отравлен." +
                " Никогда еще мне столько не платили за пузырек родниковой воды.", "");

            await Say(Skull, "Ты завяжешь нам глаза или тоже опоишь своими настойками," +
                " чтобы не запомнили дорогу к святыне эльфов?", "");

            await Say(Tiir, "Зачем? Если все получится, наши судьбы сплетуться воедино," +
                " если нет, вы и так не сможете никому показать дорогу.", "");

            await Say(Skull, "Не поспоришь.", "");

            Fork();
        }
    }
}
