namespace FirGames.StoryPart3
{
    public class P3Scene1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Castle);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "���������! �� � ����� ������� � ���������� ��� ��������. " +
                "�� ����� ������ ������� ������, � �� ������ ���������. ������� �� ���������!", "");

            Fork();
        }
    }
}
