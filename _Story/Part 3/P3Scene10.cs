namespace FirGames.StoryPart3
{
    public class P3Scene10 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Tiir = storyInformator.Tiir;

            Scene(storyInformator.PortalOn);

            Show(Skull, PositionOnTheStage.Left);
            Show(Tiir, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "Отлично, портал работает. Вперед.", "");

            Fork();
        }
    }
}
