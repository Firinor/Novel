namespace FirGames.StoryPart4
{
    public class P4Scene29 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator MagicianElector = Characters.MagicianElector;
            CharacterInformator Skull = Characters.Skull;

            Show(MagicianElector, PositionOnTheStage.Center);

            await Say(MagicianElector, "��� �������������. ������ � ������, " +
                "������ �� ���-������ ����������� ����� ��� ��� � ������ ����������?", "");

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "������.", "");

            HideCharacter(Skull);

            await Say(MagicianElector, "�������. �� � ���� ��� ����������. " +
                "������������� ������ ������ ������������ - �������� ��������, ���������� ���� ������ ����.", "");

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "��� �� ����. ����� �� �������! " +
                "� �� �������� �� ����������, ��� ��� ������ ���������� �������!", "");

            await Say(Skull, "��� � ������ ������� � ����� ��������� ����������. ��� �� ���������?", "");

            Fork();
        }
    }
}
