namespace FirGames.StoryPart4
{
    public class P4Scene19 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Arguz = Characters.Arguz;

            Scene(Backgrounds.CommanderInChiefsTent);

            Show(Skull, PositionOnTheStage.Left);
            Show(Arguz, PositionOnTheStage.Right);

            await Say(Skull, "Нам придется углубиться в земли орков. " +
                "Сам Вацела редко убивает посланников, но я не столь уверен в его подданных.", "");
            await Say(Skull, "К счастью, магия ордена Познающих это не только порталы." +
                " Применим заклинание искажения пространства, чтобы пройти незаметно.", "");

            Fork();
        }
    }
}
