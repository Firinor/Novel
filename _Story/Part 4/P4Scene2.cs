namespace FirGames.StoryPart4
{
    public class P4Scene2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Yanus = Characters.Yanus;

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Left);
            Show(Yanus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Yanus, "������ ������� ���� ������ �� ������ �������, " +
                "����������� ������� ����� ������������ ���� ������ ����.", "");

            await Say(Skull, "� ����, ��� �� ������������� �� ���������, ��, " +
                "������ ��� ������������, ����� ���-������ �� �������.", "");

            await Say(Yanus, "���������� � ����������. �����, ��� ��� ���� ���������, ��� ������� ������.", "");

            Fork();
        }
    }
}
