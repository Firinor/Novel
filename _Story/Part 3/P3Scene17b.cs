namespace FirGames.StoryPart3
{
    public class P3Scene17b : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "������ �� ���������. ������, ���� ������ �� ��������.", "");

            Fork();
        }
    }
}
