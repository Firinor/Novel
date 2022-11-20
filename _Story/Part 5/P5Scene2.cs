namespace FirGames.StoryPart3
{
    public class P3Scene2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Vargus = Characters.Vargus;

            Scene(Backgrounds.FirePlace);

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
