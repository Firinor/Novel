namespace FirGames.StoryPart4
{
    public class P4Scene1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator MagicianElector = Characters.MagicianElector;
            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Vargus = Characters.Vargus;

            Scene(Backgrounds.FirePlace);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "������ ���� ������� ������ ������������. " +
                "�� ������� ���, ��� �����, �������� ����� �������.", "");

            HideCharacter(Skull);

            Scene(Backgrounds.Lab);

            Show(MagicianElector, PositionOnTheStage.Center, ViewDirection.Left);

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

            Show(MagicianElector, PositionOnTheStage.Center, ViewDirection.Right);

            await Say(Vargus, "�� �� ������ ����� ��� ������! � ������ ������ ��, ���������, �������� �� ���� ���?", "");

            Show(MagicianElector, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Skull, "��� � ������ ������� � ����� ��������� ����������. ��� �� ���������?", "");

            Fork();
        }
    }
}
