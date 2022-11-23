namespace FirGames.StoryPart4
{
    public class P4Scene18 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Arguz = Characters.Arguz;

            Scene(Backgrounds.CommanderInChiefsTent);

            Show(Skull, PositionOnTheStage.Left);
            Show(Arguz, PositionOnTheStage.Right);

            await Say(Arguz, "������� �����! �� ���� �, ��� ��� ������� �������, " +
                "��� �� ������� ���������� � ���� ���������. � ����, �� ������� ������� �����!", "");

            Fork();
        }
    }
}
