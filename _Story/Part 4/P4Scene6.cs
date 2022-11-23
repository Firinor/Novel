namespace FirGames.StoryPart4
{
    public class P4Scene6 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Mercenary = Characters.Mercenary;

            Scene(Backgrounds.PortalOn);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "�� ����� � �������. ����� �� ������ ����, ���� ����� �������� � ���������.", "");
            await Say(Skull, "����� �������� ����������� ������������, ���������� ��������� ����������� �������," +
                " ������� ��������� � ���� �������� ������� �����.", "");

            Show(Mercenary, PositionOnTheStage.Right);

            await Say(Skull, "�������� ������� ����������, ��� ��������� ���� ���." +
                " ������ �� ������, ���� �� ������ �� ���������.", "");

            Fork();
        }
    }
}
