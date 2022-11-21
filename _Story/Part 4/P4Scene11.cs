namespace FirGames.StoryPart4
{
    public class P4Scene11 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Nogation = Characters.Nogation;

            Show(Skull, PositionOnTheStage.Center);

            Scene(Backgrounds.Tents);

            await Say(Skull, "������ �������� ������� �����.", "");

            Show(Nogation, PositionOnTheStage.Left);

            await SayByName(Nogation, "���", "Orc",
                "� ����� �������, �� �� ����� �������!", "");

            await Say(Skull, "���� �������� ����� �����, ���� ���� �����. " +
                "���� ������� ���� ������ ������ ����� ������.", "");
            await Say(Skull, "��������� �� ����. ���, �� ������� ����. ���� � ����� ����������.", "");

            Fork();
        }
    }
}
