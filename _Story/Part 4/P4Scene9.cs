namespace FirGames.StoryPart4
{
    public class P4Scene9 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            await ShowImage(Backgrounds.War);

            CharacterInformator Skull = Characters.Skull;

            Show(Skull, PositionOnTheStage.Center);

            Scene(Backgrounds.Tents);

            await Say(Skull, "�������, �� ������ ��������� �������� � ����� �������� ������," +
                " �� ��� ���� ������. ������� ����� ���� � ����.", "");
            await Say(Skull, "������ ������� ����� ���������� � ����� �� ����� �������������� �� �����.", "");

            Fork();
        }
    }
}
