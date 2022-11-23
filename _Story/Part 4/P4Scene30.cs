namespace FirGames.StoryPart4
{
    public class P4Scene30 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;
            CharacterInformator Arguz = Characters.Arguz;
            CharacterInformator Hurga = Characters.Hurga;

            Scene(Backgrounds.OrcCamp);

            Show(Bathyard, PositionOnTheStage.Left);
            Show(Skull, PositionOnTheStage.Center, ViewDirection.Right);
            Show(Arguz, PositionOnTheStage.Left);

            await Say(Skull, "��� ���������� ��� ������ �����! ����� � ��� ����� �������� " +
                "�� ���� ������! ��� ���� �� ������� ������ ��������.", "");

            await Say(Bathyard, "�����! �, ������, ��� ������ ������ ���, ��� ����� ���������, ������������ �����." +
                " ����, ��� ����� ����� � ���, ���� ������!", "");

            await Say(Skull, "������-��, ������. ����� ������, � ���� �������.", "");

            await Say(Bathyard, "�����, ������ ���������� ���� ��������.", "");

            Show(Hurga, PositionOnTheStage.Right);

            await Say(Hurga, "������ ������ ���� ����� �� ������.", "");

            await Say(Bathyard, "�� ���� ���������� � �����. �� ��� �����������!", "");

            await Say(Skull, "�����-�����. �� ��� ���?", "");

            await Say(Bathyard, "��� ����������?", "");

            await Say(Skull, "�� ����� ����! ����� �� ���, �� �������. ����� �� ����, " +
                "���������� ������� �����, ������ �������� �������.", "");
            await Say(Skull, "������ ������� ��� ����� �����, �� ��� �� ������� �����, " +
                "�������� ������� ��������.", "");

            await Say(Arguz, "��������� ������ ��� �������� ������. ������� �� ������� �������, " +
                "��� ������ ����� ����� �� ���?", "");

            await Say(Bathyard, "���� ���������� � ����� �����.", "");

            Fork();
        }
    }
}
