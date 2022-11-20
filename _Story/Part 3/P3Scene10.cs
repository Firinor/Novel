namespace FirGames.StoryPart3
{
    public class P3Scene10 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Tiir = Characters.Tiir;

            Scene(Backgrounds.PortalOn);

            Show(Skull, PositionOnTheStage.Left);
            Show(Tiir, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "Отлично, портал работает. Вперед.", "");

            Fork();
        }
    }
}
