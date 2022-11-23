namespace FirGames.StoryPart4
{
    public class P4Scene21 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Bathyard = Characters.Bathyard;
            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.OrcEncampment);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "��� � ��������. ���� ����� ������. " +
                "������ �������� �� ���� �������� ����. ���� �� ���������� �� ��� �����.", "");

            Show(Skull, PositionOnTheStage.Left);
            Show(Bathyard, PositionOnTheStage.Right);

            await Say(Bathyard, "��� �� � ����� ������?", "");

            await Say(Skull, "�� �������� ���� �������� ����� ������ �� ������� ����� ������.", "");

            await Say(Bathyard, "��������� ����������! ������, ����� �� ���� ����� ����� �������" +
                " ���� ������, ���� ������ ��������.", "");
            await Say(Bathyard, "��� �������������: ��������� ������, ������ ������� ������, " +
                "����������� ������, �������� ������� ����?", "");

            await Say(Skull, "����� ���� �������, ����� �������� � ������������?", "");

            await Say(Bathyard, "��� ����� ���� ���������� ����� ������?", "");

            await Say(Skull, "��������. ������� ������ ������ ���������� � �������� ���������" +
                " �� ������ ������, �� ���� ��� �� ������� ������� ��������.", "");

            await Say(Bathyard, "� �� ��������! ����, ������ � ����.", "");

            Fork();
        }
    }
}
