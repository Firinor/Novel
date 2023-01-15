namespace FirGames.StoryPart4
{
    public class P4Scene3 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            await ShowImage(Backgrounds.TwoDaysHavePassed);

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Бумаги с подписями, печати с бумагами, подписи с печатями - и так целыми днями.", "");
            await Say(Skull, "Где те времена, когда мы конструировали портал, экспериментировали," +
                " чуть не взорвали библиотеку ордена.", "");

            Fork();
        }
    }
}
