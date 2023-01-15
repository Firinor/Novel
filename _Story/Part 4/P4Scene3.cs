namespace FirGames.StoryPart4
{
    public class P4Scene3 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            await ShowImage(Backgrounds.TwoDaysHavePassed);

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "������ � ���������, ������ � ��������, ������� � �������� - � ��� ������ �����.", "");
            await Say(Skull, "��� �� �������, ����� �� �������������� ������, ������������������," +
                " ���� �� �������� ���������� ������.", "");

            Fork();
        }
    }
}
