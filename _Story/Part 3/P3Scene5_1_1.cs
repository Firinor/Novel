namespace FirGames.StoryPart3
{
    public class P3Scene5_1_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Guard = Characters.HumanGuard;

            Scene(Backgrounds.Prison);

            Show(Skull, PositionOnTheStage.Left);
            Show(Guard, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Guard, "�� � ����?", "");

            await Say(Skull, "��������� ���� �����?", "");

            await Say(Guard, "��, �� ��������� �� ���������� ���.", "");

            await Say(Skull, "����� ��� �������?", "");

            await Say(Skull, "�� � �������� ������� ������ ������ ��� ��������." +
                " �������� ��������� � � ��� �������.", "");

            Fork();
        }
    }
}
