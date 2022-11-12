namespace FirGames.StoryPart3
{
    public class P3Scene2_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Vargus = storyInformator.Vargus;

            Scene(storyInformator.FirePlace);

            Show(Skull, PositionOnTheStage.Left);
            Show(Vargus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Skull, "�� ���� ��������� � ����� ��������, ������� ������� ���������?!", "");

            await Say(Vargus, "����������! � ������ ��������� �� ������ ����� ���� �� �� ����, � � ���������.", "");

            Fork();
        }
    }
}
