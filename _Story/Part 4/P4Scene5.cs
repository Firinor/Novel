namespace FirGames.StoryPart4
{
    public class P4Scene5 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Ermingarda = Characters.Ermingarda;

            Scene(Backgrounds.ThroneRoom);

            Show(Skull, PositionOnTheStage.Left);
            Show(Ermingarda, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Ermingarda, "�� ������������ ������������, �������� ��������, � ������� ������� ��� �������.", "");

            await Say(Skull, "���� ��������, ���� ����������.", "");

            await Say(Ermingarda, "����� ������ ����� ������ ������������ ��������" +
                " � ������� � �� ������ ��������� ������� ���� �� ������������ ������.", "");

            await Say(Skull, "�� ���� ��������� ����� ������ � ��������?", "");

            await Say(Ermingarda, "� ���� ������� ����� ����� ������ ������ ��������." +
                " �� ������, ����� �� ����� ����������� � ��������.", "");
            await Say(Ermingarda, "�������, ������ ��� ����� ��� ������ �� ����� ������ ������� ������," +
                " ������� ����������� �������� ���� ����� �� ��������� �����.", "");

            await Say(Skull, "����� ������ ��������� ������ ������� ��������, ��," +
                " ��� ���� ��������, ��������, ���� ����� ������� �����?", "");

            await Say(Ermingarda, "� ������������ ������ ����� �� ������ �������� ���������, �� � ��." +
                " �������� ���� ������ ������ ����� ������������ ���� ������������.", "");
            await Say(Ermingarda, "���������� ������������ ��� ����� ������, ������ ��� � ����� �������� �� ������.", "");

            await Say(Skull, "��� ���������.", "");

            await ShowImage(SpecialImages.TwoDaysHavePassed);

            Fork();
        }
    }
}
