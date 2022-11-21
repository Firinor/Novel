namespace FirGames.StoryPart4
{
    public class P4Scene8_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Mercenary = Characters.Mercenary;

            Show(Mercenary, PositionOnTheStage.Right);
            Show(Skull, PositionOnTheStage.Left, ViewDirection.Left);

            Scene(Backgrounds.Tents);

            await Say(Skull, "Орки мчатся сюда, но к чему была такая жестокость?" +
                " Если бы у меня были уши, они бы отвалились.", "");

            Fork();
        }
    }
}
