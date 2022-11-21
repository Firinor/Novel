namespace FirGames.StoryPart4
{
    public class P4Scene8_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Mercenary = Characters.Mercenary;

            Show(Mercenary, PositionOnTheStage.Right);
            Show(Skull, PositionOnTheStage.Left, ViewDirection.Left);

            Scene(Backgrounds.Tents);

            await Say(Skull, "Шикарное представление! Гляди, орки мчатся сюда на своих вепрях.", "");

            Fork();
        }
    }
}
