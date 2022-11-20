namespace FirGames.StoryPart3
{
    public class P3Scene10_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.PortalOn);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "� ��� ��� ������. ���� ������ �������� ����� ������������," +
                " ���� ��� �����������. ���� ����� - ��� �������, ���� ��������� � ������� - ��� ��������.", "");

            await Say(Skull, "������ ��������� � ����� ������������. ���� ������. ���, ���, ���.", "");

            Fork(soloButton: true);
        }
    }
}
