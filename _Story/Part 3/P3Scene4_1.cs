namespace FirGames.StoryPart3
{
    public class P3Scene4_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Fun);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Бараньи рога ему подойдут. Пусть королева увидит, с кем заключила союз.", "");

            Fork();
        }
    }
}
