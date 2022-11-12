namespace FirGames.StoryPart3
{
    public class P3Scene4_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Fun);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Разумно говоришь. Не будем вести себя как обиженные дети.", "");

            Fork();
        }
    }
}
