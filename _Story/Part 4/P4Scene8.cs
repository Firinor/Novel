namespace FirGames.StoryPart4
{
    public class P4Scene8 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Mercenary = Characters.Mercenary;

            Show(Mercenary, PositionOnTheStage.Right, ViewDirection.Right);
            Show(Skull, PositionOnTheStage.Left);

            Scene(Backgrounds.Tents);

            await Say(Skull, "����� ������������ ��������� ����� �����.", "");
            await Say(Skull, "���� ��� �������, ��������� �������� ������ ������ � �� ������ ������" +
                " ��� ������� ���� � ��������. ����� ��������� �� ��������.", "");

            Fork();
        }
    }
}
