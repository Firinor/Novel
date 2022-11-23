namespace FirGames.StoryPart4
{
    public class P4Scene1_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Vargus = Characters.Vargus;

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Left);
            Show(Vargus, PositionOnTheStage.Right);

            await Say(Skull, "������, �� ����� ����������� � �������� �����, " +
                "��� ����� �������� � ��������� ����������. ����� �������� ������� ���� ��������� �����?", "");

            await Say(Vargus, "� ������ ������. ���� ������ � ������ ������� ����� �������, ��� ���� �����������.", "");

            await Say(Skull, "��, � ���� �������, ������ ������� ���� ������.", "");

            Fork();
        }
    }
}
