namespace FirGames.StoryPart3
{
    public class P3Scene18_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Tiir = Characters.Tiir;

            Scene(Backgrounds.AtElvenPalace2);

            Show(Skull, PositionOnTheStage.Left);
            Show(Tiir, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Tiir, "������ ��������, �� ��������� ���������� ������. " +
                "� ����� ������, � ��������� ��� �� ����� ������ ������.", "");

            Fork();
        }
    }
}
