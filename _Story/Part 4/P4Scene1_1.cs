namespace FirGames.StoryPart4
{
    public class P4Scene1_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Vargus = Characters.Vargus;

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Left);
            Show(Vargus, PositionOnTheStage.Right);

            await Say(Skull, "¬аргус, ты много рассуждаешь о важности опыта, " +
                "так прими ситуацию с мудростью старейшины. –азве подобает зрелому магу обиженное нытье?", "");

            await Say(Vargus, "я уважаю обычаи. ≈сли брать€ и сестры прин€ли такое решение, мой долг подчинитьс€.", "");

            await Say(Skull, "ћы, в свою очередь, готовы уважать твои знани€.", "");

            Fork();
        }
    }
}
