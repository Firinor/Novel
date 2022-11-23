namespace FirGames.StoryPart4
{
    public class P4Scene28 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;

            Scene(Backgrounds.OrcCamp);

            Show(Bathyard, PositionOnTheStage.Right);
            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "������, ������, ������� ��� ������ ������� �� ����.", "");

            await Say(Bathyard, "�����! ���� �������, ��� ��� ����� �� ������ �������� � �����! " +
                "�����, ��� ������� ����� ����� ���������� �������! �� �� ������� �������� �������!", "");

            await SayByName(null, "����-�����", "", "�����! �����! �����!", "");

            await Say(Bathyard, "���������! � ����� ��� ������ � ����� �������!", "");

            await Say(Skull, "������� � �������, �� �� ����� ������. ��������� ��������� �������, " +
                "����� ��� ����� ��� ��� ������� ����� ���� ���� ���, ��� �� ����������� �����.", "");

            await Say(Bathyard, "�����, ���� � ������.", "");

            Fork();
        }
    }
}
