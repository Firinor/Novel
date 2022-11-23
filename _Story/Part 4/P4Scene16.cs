namespace FirGames.StoryPart4
{
    public class P4Scene16 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.CommanderInChiefsTent);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "������� ��� ������ �� ������� ��������������� �����." +
                " ����� ����� �� ����� ������. ��� ����� ��� � � ��������. ����� ������� �������, ����� ���������.", "");

            Fork();
        }
    }
}
