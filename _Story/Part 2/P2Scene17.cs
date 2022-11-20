namespace FirGames.StoryPart2
{
    public class P2Scene17 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "�������� ��������� ��� ������ �� ������� ��������, ������� ������������ " +
                "������ �� ���������� ����������� ����. ��� ����� �������, ��������� ����� ���������.", "");
            await Say(Skull, "��� �� �������, ��� ����� ��������� �� ���������� �� ����� ������ ����. " +
                "�������� ������������, ��� � ���� ���� ��� �� ��� ������.", "");

            Fork();
        }
    }
}