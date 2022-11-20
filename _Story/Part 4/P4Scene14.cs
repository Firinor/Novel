namespace FirGames.StoryPart4
{
    public class P4Scene14 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator MagicianElector = Characters.MagicianElector;
            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Vargus = Characters.Vargus;

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

            Show(Vargus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Vargus, "�� �� ������ ����� ��� ������! � ������ ������ ��, ���������, �������� �� ���� ���?", "");

            await Say(Skull, "��� � ������ ������� � ����� ��������� ����������. ��� �� ���������?", "");

            Fork();
        }
    }
}
