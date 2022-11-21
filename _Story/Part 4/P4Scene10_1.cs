namespace FirGames.StoryPart4
{
    public class P4Scene10_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Show(Skull, PositionOnTheStage.Center);

            Scene(Backgrounds.Tents);

            await Say(Skull, "Ѕольше они не смогут никому навредить.", "");

            Fork();
        }
    }
}
