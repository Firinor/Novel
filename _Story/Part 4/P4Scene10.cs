namespace FirGames.StoryPart4
{
    public class P4Scene10 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Mercenary = Characters.Mercenary;

            Show(Skull, PositionOnTheStage.Center);
            Show(Mercenary, PositionOnTheStage.Right);

            Scene(Backgrounds.Tents);

            await Say(Skull, "�������: ������ �������� �� �������� ��� ����������� ����� ���� ���� ��������?", "");

            await Say(Mercenary, "�����?! ���, ������ �� ���. � ��� �����.", "");

            await Say(Skull, "�������� ��������� ����� ������������?", "");

            await Say(Mercenary, "�� � ������� ������� �������. ��� ������ ���� ��������� ��� ���������� ������.", "");

            await Say(Skull, "��� ����� � ���� ������?", "");

            Fork();
        }
    }
}
