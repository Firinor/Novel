namespace FirGames.StoryPart4
{
    public class P4Scene1_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Vargus = Characters.Vargus;

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Center);
            Show(Vargus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "�� ���������, ������, ���� ���� ���� ����� ��������� " +
                "��������� ������� � ������� ������ ��������.", "");
            await Say(Skull, "�������� ������ ������������ ������������ ������������.", "");

            await Say(Vargus, "�� ��� ��� ��� ��������!", "");

            await Say(Skull, "�������, ������ ��������� �������� � ����� ������ ����� ��������.", "");

            Fork();
        }
    }
}
