namespace FirGames.StoryPart4
{
    public class P4Scene29 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;
            CharacterInformator Arguz = Characters.Arguz;

            Scene(Backgrounds.CommanderInChiefsTent);

            Show(Bathyard, PositionOnTheStage.Left);
            Show(Skull, PositionOnTheStage.Left);
            Show(Arguz, PositionOnTheStage.Right);

            await Say(Arguz, "��� ������� ������� ����� ������?", "");

            await Say(Bathyard, "���� ������ ���� �����������, �� ����� ��� ������.", "");

            await Say(Skull, "���� ����. ����� ������������ ���������� ��� ��������. " +
                "������� � ������ ���������� ������. ��� ������ ����� ������ � ������, ������� �����������.", "");

            await Say(Arguz, "������. ������� ������.", "");

            await ShowImage(SpecialImages.TwoDaysHavePassed);

            Fork();
        }
    }
}
