namespace FirGames.StoryPart4
{
    public class P4Scene13 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.Desert);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "����� ������, �� ������ ����� �������, ������� ����� �������� ������. " +
                "����� ����������, ������ ���������� ������.", "");
            await Say(Skull, "������� ��� ������ ��� �� ������� ����� �����������. " +
                "������� � ���� ��� �� ������ �� ��������, � ��������� ��������?", "");
            await Say(Skull, "��� �� �� �� ����, ��� ����� �������� ������ ������� ������ � ������������ ��� � ������.", "");

            Fork();
        }
    }
}
