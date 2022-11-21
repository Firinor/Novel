namespace FirGames.StoryPart4
{
    public class P4Scene9 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Show(Skull, PositionOnTheStage.Center);

            Scene(Backgrounds.Tents);

            await ShowImage(SpecialImages.War);

            await Say(Skull, "�������, �� ������ ��������� �������� � ����� �������� ������," +
                " �� ��� ���� ������. ������� ����� ���� � ����.", "");
            await Say(Skull, "������ ������� ����� ���������� � ����� �� ����� �������������� �� �����.", "");

            Fork();
        }
    }
}
