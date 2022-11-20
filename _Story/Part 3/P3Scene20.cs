namespace FirGames.StoryPart3
{
    public class P3Scene20 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.TiirRoom);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "������ ������� ������ ���������� ��������� ������ ���� - ��� ��������� �����. " +
                "�������� ���� ������ ������ ���� � ��� ������ ������� � ���� �� ����������.", "");

            Fork();
        }
    }
}
