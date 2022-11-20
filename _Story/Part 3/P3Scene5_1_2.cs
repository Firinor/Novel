namespace FirGames.StoryPart3
{
    public class P3Scene5_1_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Yanus = Characters.Yanus;

            Scene(Backgrounds.Prisoners�ell);

            Show(Skull, PositionOnTheStage.Left);
            Show(Yanus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "����� ��� �������, �� ��� ��� �������� � ���������. ���� ��� ���� ����� �������?", "");

            await Say(Yanus, "�����, ���� ������ ������� ������� �������� � �� ������ ����.", "");

            await Say(Skull, "������, �� ������ ���������.", "");

            await Say(Yanus, "� �������� �����, ��� ��� ���� ����������� ������, �� �� ���� ����������� �������� ������.", "");

            await Say(Skull, "���������� ������ ���� �� ����������, ���� ��� ���� ������ ���� �������� ���� �����������.", "");

            await Say(Yanus, "��������� ������ ��� �������.", "");

            await Say(Skull, "� ��� ����������� ����� ���� �� ������ ����� ����������.", "");

            Fork();
        }
    }
}
