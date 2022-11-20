namespace FirGames.StoryPart3
{
    public class P3Scene18 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.AtElvenPalace2);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "��� ������������, ������ �� � �������� ����. " +
                "������ �� ����� ��� �������� ������������� ������.", "");

            await Say(Skull, "�������, ������������� ����� �������� �� ������ ����������� �������, " +
                "�� � ��������� ����������. � ��� ��� �� ��������� ����� ������ �������.", "");

            await Say(Skull, "�� ��������� ������ � ������ ����� ����� ������� ���������," +
                " �� ����� �������� ���������� ������ ���������� � ������.", "");

            await Say(Skull, "��� ����� ��������� ������, ��� �������, � ������ ����� ��� �����������.", "");

            Fork();
        }
    }
}
