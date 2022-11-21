namespace FirGames.StoryPart4
{
    public class P4Scene7 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Mercenary = Characters.Mercenary;

            Show(Mercenary, PositionOnTheStage.Left);
            Show(Skull, PositionOnTheStage.Right, ViewDirection.Right);

            Scene(Backgrounds.DesertPortalOn);

            await Say(Skull, "�� ������ �� ����������� �����. ��������, ���� ���������" +
                " ������ ������ �� ���� ����� ��������.", "");
            await Say(Skull, "��������� � ��������� ����� ������������ ������ � ���� �������������� ��� �����.", "");
            await Say(Skull, "����-���� ������ ������, �� ����� �������� ��������� ��� �� �������." +
                " ��, ��� ���� ������� �������: ������� � ��������, ������ � ���������.", "");
            await Say(Skull, "���� ������� � ������ ������� ������������. �����, ������ � ������." +
                " ��� ������ ��������� �����������.", "");

            Fork();
        }
    }
}
