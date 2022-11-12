namespace FirGames.StoryPart3
{
    public class P3Scene3 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Voice = storyInformator.Voice;

            Scene(storyInformator.FirePlace);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "���� ��� �������� ����������� ��������." +
                " ���� � ������� ������ ��� ��� ���� �� ������ �� � ������.", "");

            await Say(Skull, "�������� ������ ���������� � �����������.", "");

            await Say(Skull, "��������� ������������ ������� ������� �������� �� ��������," +
                " ������� ����� ���� ����������.", "");

            await Say(Skull, "��������� �������� ������� ������. ����� ��������, ��� ���������������� �������.", "");

            await Say(Voice, "��-��-��-��������!!!", "");

            await Say(Skull, "�� ������� ����? ��� ��� ����������? ������ ������ �����.", "");

            Fork();
        }
    }
}
