namespace FirGames.StoryPart3
{
    public class P3Scene2_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Vargus = storyInformator.Vargus;

            Scene(storyInformator.FirePlace);

            Show(Skull, PositionOnTheStage.Left);
            Show(Vargus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Skull, "Не смог преуспеть в магии порталов, поэтому занялся интригами?!", "");

            await Say(Vargus, "Осторожнее! В случае нарушения вы будете иметь дело не со мной, а с королевой.", "");

            Fork();
        }
    }
}
