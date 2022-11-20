namespace FirGames.StoryPart3
{
    public class P3Scene16 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Voice = Characters.Voice;

            Scene(Backgrounds.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Voice, "������� ����� ������� ��������� ��� ������, �� �� ������� �� ������ �������� �����.", "");

            await Say(Skull, "��������� �� ��������� �������� � ������� �� ������." +
                " ������ ��� �� �������� � ���� ��������� �������.", "");

            Fork();
        }
    }
}
