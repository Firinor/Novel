namespace FirGames.StoryPart4
{
    public class P4Scene28 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;

            Scene(Backgrounds.OrcCamp);

            Show(Bathyard, PositionOnTheStage.Right);
            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Батярд, смотри, кажется там голова Ногация на пике.", "");

            await Say(Bathyard, "Войны! Духи говорят, что пес Аргуз не должен остаться в живых! " +
                "Земля, где пролита кровь орков становится родиной! Мы не оставим Карпатию шакалам!", "");

            await SayByName(null, "Орки-воины", "", "Кровь! Кровь! Кровь!", "");

            await Say(Bathyard, "Предатель! Я вырву его сердце и брошу собакам!", "");

            await Say(Skull, "Вырвешь и бросишь, но не прямо сейчас. Подствоим предателю ловушку, " +
                "чтобы при свете дня все увидели какая кара ждет тех, кто не подчиняется вождю.", "");

            await Say(Bathyard, "Ладно, идем к Аргузу.", "");

            Fork();
        }
    }
}
