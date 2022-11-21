namespace FirGames.StoryPart4
{
    public class P4Scene10_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Show(Skull, PositionOnTheStage.Center);

            Scene(Backgrounds.Tents);

            await Say(Skull, "��������� ������ �� �� �����. ����� � ����������� ������ �� ��������� ��������.", "");
            await Say(Skull, "������ �� ����������, �� �� ��������� �� �������� ������������ �� ������ ���.", "");

            Fork();
        }
    }
}
