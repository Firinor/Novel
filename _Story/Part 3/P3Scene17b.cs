namespace FirGames.StoryPart3
{
    public class P3Scene17b : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "������ �� ���������. ������, ���� ������ �� ��������.", "");

            Fork();
        }
    }
}
