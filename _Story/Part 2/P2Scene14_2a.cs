namespace FirGames.StoryPart2
{
    public class P2Scene14_2a : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "�����������! ������ �������� �������� ������� � " +
                "����� ���� ������� � ����������� �����.", "");

            Fork();
        }
    }
}