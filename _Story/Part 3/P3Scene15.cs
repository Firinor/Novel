namespace FirGames.StoryPart3
{
    public class P3Scene15 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Voice = storyInformator.Voice;

            Scene(storyInformator.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Voice, "����� �� ��� �������!", "");

            await Say(Skull, "����! �������! ����, �� �� �������. �� ��� ����������!" +
                " ���� �� � ���� ���� ������, ��� �� ������������.", "");

            await Say(Voice, "������� ��� � ������� ��������?", "");

            Fork();
        }
    }
}
