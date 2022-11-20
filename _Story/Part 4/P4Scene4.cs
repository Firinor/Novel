namespace FirGames.StoryPart4
{
    public class P4Scene4 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator HumanGuard = Characters.HumanGuard;

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Left);
            Show(HumanGuard, PositionOnTheStage.Right);

            await Say(HumanGuard, "Могу я войти?", "");

            await Say(Skull, "Входи, если не боишься заснуть.", "");

            await Say(HumanGuard, "Прошу прощения, архимагистр. Ее Величество Эрмингарда желает вас видеть.", "");

            await Say(Skull, "Этого-то я и боялся. Два месяца от нее не было вестей, " +
                "а сейчас сразу личная аудиенция. Дурной знак!", "");

            Fork();
        }
    }
}
