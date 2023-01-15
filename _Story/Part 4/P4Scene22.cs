namespace FirGames.StoryPart4
{
    public class P4Scene22 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;
            CharacterInformator Nogation = Characters.Nogation;
            CharacterInformator Vacela = Characters.Vacela;

            Scene(Backgrounds.OrcCommanderInChiefsTent);

            Show(Vacela, PositionOnTheStage.Center, ViewDirection.Left);
            Show(Skull, PositionOnTheStage.Left);
            Show(Bathyard, PositionOnTheStage.Right);
            Show(Nogation, PositionOnTheStage.Right);

            await Say(Vacela, "����������? ������ ��������� ��� ����� ������?", "");

            await Say(Skull, "������������ ����� ��������� � ����������� �������� ����� ������." +
                " ������� � �������� ���� ������� � �������� ����� �������.", "");

            await Say(Vacela, "���-�� ���������. ��������. ��� �� ��� �����?", "");

            await Say(Skull, "������� ��� ������ ������ ����������. �� ����� ��������� ������� ��� ��������� ���������.", "");

            await Say(Vacela, "����� ����� �������� ������. ��� �� �����?", "");

            await Say(Skull, "������ ����� ��������, ��� � ��� ���� ����� ��������� �����, ��� ��.", "");

            await Say(Vacela, "��������� ��������. ����� ����� ����� �����.", "");

            await Say(Skull, "������ ������ ��������� ���.", "");

            await Say(Vacela, "��� �� ����������?", "");

            await Say(Skull, "���, ��������� �� �������� ����������, ������� �����.", "");

            await Say(Vacela, "����� ������ ����� �� ������. ������ � ��� ����.", "");

            Show(Vacela, PositionOnTheStage.Center, ViewDirection.Right);
            await Say(Vacela, "�������, ����������� � ����� � �������, ��� � ���������� ������������ � ��������.", "");
            await Say(Vacela, "������, �� ����������� �� �������.", "");

            await Say(Skull, "����� ����������� �����.", "");

            Show(Vacela, PositionOnTheStage.Center, ViewDirection.Left);
            await Say(Vacela, "������  ������ ��������. ������ ������� �� ���� ����" +
                " � ����� ��������� ���������� ����� �����.", "");

            await Say(Skull, "������ �� �����.", "");

            await ShowImage(Backgrounds.OrcParty);

            Fork();
        }
    }
}
