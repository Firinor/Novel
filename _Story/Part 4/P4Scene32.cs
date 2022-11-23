namespace FirGames.StoryPart4
{
    public class P4Scene32 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Arguz = Characters.Arguz;

            Scene(Backgrounds.OrcCamp);

            Show(Skull, PositionOnTheStage.Left);
            Show(Arguz, PositionOnTheStage.Right);

            await Say(Arguz, "������ ����� ������ � �������. �� �������� ����� �� ������ ������.", "");

            await Say(Skull, "��� ����� �� ������ �������� �������� ���������� ������ � ����� ����� " +
                "�������� ��� ������ �������.", "");

            await Say(Arguz, "������� ����. ������ ������� ����� ������� ������� � ��������, " +
                "����� ����������� �������� ������ �� �����.", "");

            await Say(Skull, "���� ����������� � ����� ����� ������ � �������.", "");
            await Say(Skull, "�������� ������������� �� �������� �� ����� ������. " +
                "��� �� ������ ��������� � ������������� � �����������.", "");

            await Say(Arguz, "� ����� ��������� �� �����? � ����� ��� ��� �������.", "");

            await Say(Skull, "���� � ��� �������� ��������� �������, ������� �� ��� ������, " +
                "�� �������� �����. � ������ ��� ��� ��������.", "");

            await Say(Arguz, "��� �� ����� � ���������.", "");

            Fork();
        }
    }
}
