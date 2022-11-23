namespace FirGames.StoryPart4
{
    public class P4Scene25 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.OrcEncampment);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "������ ����� �� �������-�� �������� ������ ���������� �����," +
                " ������� ���������� �� ������� ����. ���������� � ��� ��� ���������.", "");

            await ShowImage(SpecialImages.TwoDaysHavePassed);

            Fork();
        }
    }
}
