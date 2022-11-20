namespace FirGames.StoryPart3
{
    public class P3Scene3 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Voice = Characters.Voice;

            Scene(Backgrounds.FirePlace);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Тоже мне любитель театральных эффектов." +
                " Ушел и хлопнул дверью так что чуть не сорвал ее с петель.", "");

            await Say(Skull, "Очевидно Варгус сговорился с Эрмингардой.", "");

            await Say(Skull, "Назначить архимагистра вопреки обычаям королева не решилась," +
                " поэтому нашла себе марионетку.", "");

            await Say(Skull, "Поддержка королевы сильный козырь. Нужно подумать, что противопоставить Варгусу.", "");

            await Say(Voice, "бу-га-га-гашеньки!!!", "");

            await Say(Skull, "Ты слышишь смех? Что там происходит? Скорее открой дверь.", "");

            Fork();
        }
    }
}
