namespace FirGames.StoryPart3
{
    public class P3Scene15 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Vargus = storyInformator.Vargus;

            Scene(storyInformator.FirePlace);

            Show(Skull, PositionOnTheStage.Left);
            Show(Vargus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Vargus, "��������� �����?", "");

            await Say(Skull, "�� ���� ���� ���� ������.", "");

            await Say(Vargus, "���, ������������ � �������� ��������.", "");

            await Say(Vargus, "�� ������� ������ ������������ ������ � ������� ����� ������ � ���� � � ����� ���������." +
                " ������������� ����� �������� ������ ��������������� ����� � ���������.", "");

            await Say(Skull, "���� �� ����, ��� ��� �������.", "");

            Fork();
        }
    }
}
