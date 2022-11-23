namespace FirGames.StoryPart4
{
    public class P4Scene32 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Arguz = Characters.Arguz;

            Scene(Backgrounds.OrcCamp);

            Show(Skull, PositionOnTheStage.Left);
            Show(Arguz, PositionOnTheStage.Right);

            await Say(Arguz, "Батярд уехал вместе с золотом. Мы выиграли время до нового набега.", "");

            await Say(Skull, "Нам ничто не мешает подарить фолианты соперникам Вацелы и пусть вожди " +
                "выясняют чьи предки сильнее.", "");

            await Say(Arguz, "Хороший план. Только сначала нужно навести порядок в Алфарахе, " +
                "иначе двоевластие разорвет страну на части.", "");

            await Say(Skull, "Орки успокоились и можно вести войско к столице.", "");
            await Say(Skull, "Предлгаю переместиться из Карпатии на землю эльфов. " +
                "Там мы сможем отдохнуть и подготовиться к наступлению.", "");

            await Say(Arguz, "А эльфы возражать не будут? И потом там нет портала.", "");

            await Say(Skull, "Есть у нас знакомый остроухий алхимик, больной на всю голову, " +
                "но доверять можно. И портал там уже построен.", "");

            await Say(Arguz, "Как же много я пропустил.", "");

            Fork();
        }
    }
}
