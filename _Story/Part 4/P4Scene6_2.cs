namespace FirGames.StoryPart4
{
    public class P4Scene6_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.PortalOn);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "�� ����� ����� ����� ����������� �������, �������� ����� �������� ����� ���� �������." +
                " ����� ������������ ��� �����������. ���� ������, ���, ���, ���.", "");

            Fork();
        }
    }
}
