namespace FirGames.StoryPart4
{
    public class P4Scene30 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;
            CharacterInformator Arguz = Characters.Arguz;
            CharacterInformator Hurga = Characters.Hurga;

            Scene(Backgrounds.OrcCamp);

            Show(Bathyard, PositionOnTheStage.Left);
            Show(Skull, PositionOnTheStage.Center, ViewDirection.Right);
            Show(Arguz, PositionOnTheStage.Left);

            await Say(Skull, "Все получилось как нельзя лучше! Хурга и его воины окружены " +
                "со всех сторон! Они явно не ожидали такого поворота.", "");

            await Say(Bathyard, "Воины! Я, Батярд, сын Вацелы говорю вам, что Хурга предатель, ослушавшийся вождя." +
                " Всех, кто будут рядом с ним, ждет смерть!", "");

            await Say(Skull, "Смотри-ка, отошли. Честь честью, а жить хочется.", "");

            await Say(Bathyard, "Хурга, участь предателей тебе известна.", "");

            Show(Hurga, PositionOnTheStage.Right);

            await Say(Hurga, "Вацела продал свою честь за золото.", "");

            await Say(Bathyard, "Не тебе рассуждать о чести. Во имя Кармильхана!", "");

            await Say(Skull, "Секир-башка. Но что это?", "");

            await Say(Bathyard, "Что происходит?", "");

            await Say(Skull, "Не может быть! Хурга не орк, он человек. Когда он умер, " +
                "заклинание иллюзии спало, открыв истинное обличье.", "");
            await Say(Skull, "Молния разрази мой лысый череп, да это же старший принц, " +
                "которого считали погибшим.", "");

            await Say(Arguz, "Племянник всегда был очарован орками. Неужели он всерьез полагал, " +
                "что сможет стать одним их них?", "");

            await Say(Bathyard, "Овца облачилась в шкуру волка.", "");

            Fork();
        }
    }
}
