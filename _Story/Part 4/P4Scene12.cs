namespace FirGames.StoryPart4
{
    public class P4Scene12 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator MagicianElector = storyInformator.MagicianElector;
            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Vargus = storyInformator.Vargus;

            Scene(storyInformator.FirePlace);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "������ ���� ������� ������ ������������. " +
                "�� ������� ���, ��� �����, �������� ����� �������.", "");

            HideCharacter(Skull);

            Scene(storyInformator.Lab);

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
