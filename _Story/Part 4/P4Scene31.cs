namespace FirGames.StoryPart4
{
    public class P4Scene31 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;
            CharacterInformator Arguz = Characters.Arguz;

            Scene(Backgrounds.OrcCamp);

            Show(Bathyard, PositionOnTheStage.Left);
            Show(Skull, PositionOnTheStage.Center, ViewDirection.Right);
            Show(Arguz, PositionOnTheStage.Right);

            await Say(Arguz, "������, ����� ��������� �����, ������ �� ��� �� ������������� ���������� ����?", "");

            await Say(Bathyard, "� �������������.", "");

            await Say(Skull, "���� ������� ���� ������� ����� ��� ������ �������, ����� �������� ������.", "");

            await Say(Bathyard, "����������� ������.", "");

            await Say(Skull, "�� ��� ���������. ������ ��������, ��� ���������� � ��� ������� ����.", "");

            await ShowImage(Backgrounds.TwoDaysHavePassed);

            Fork();
        }
    }
}
