namespace FirGames.StoryPart4
{
    public class P4Scene4 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator HumanGuard = Characters.HumanGuard;

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Left);
            Show(HumanGuard, PositionOnTheStage.Right);

            await Say(HumanGuard, "���� � �����?", "");

            await Say(Skull, "�����, ���� �� ������� �������.", "");

            await Say(HumanGuard, "����� ��������, �����������. �� ���������� ���������� ������ ��� ������.", "");

            await Say(Skull, "�����-�� � � ������. ��� ������ �� ��� �� ���� ������, " +
                "� ������ ����� ������ ���������. ������ ����!", "");

            Fork();
        }
    }
}
