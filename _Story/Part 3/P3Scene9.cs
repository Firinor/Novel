namespace FirGames.StoryPart3
{
    public class P3Scene9 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Tiir = Characters.Tiir;

            Scene(Backgrounds.ElvenPalace);

            Show(Skull, PositionOnTheStage.Left);
            Show(Tiir, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Tiir, "�� ������.", "");

            await Say(Skull, "��������?", "");

            await Say(Tiir, "���������� ������� ��� ���.", "");

            await Say(Skull, "...", "");
            await Say("���!", "");

            await Say(Skull, "� ���� �� ������ ���� �����!", "");

            await Say(Tiir, "��������� ������ ����� �������.", "");

            await Say(Skull, "������ ����� �������� ����� ������ ����������. ��������� � �������������.", "");

            Fork();
        }
    }
}
