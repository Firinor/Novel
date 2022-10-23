using UnityEngine;

namespace FirGames.StoryPart1
{
    public class P1Scene6 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator WhiteNecromant = storyInformator.WhiteNecromant;
            CharacterInformator Yanus = storyInformator.Yanus;

            Scene(storyInformator.World);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "���� � ����?! ��� ���� �����, ������� ������?", "");

            Show(WhiteNecromant, PositionOnTheStage.Right);

            await Say(WhiteNecromant, "�����������, ���� ���.", "");

            await Say(Skull, "� �� ���� ��� �� ���� �����������, ����? � ������, " +
                "��������� �� ���-������ ����������� ��������� �������� ������� �� ���� ������.", "");

            Hide(WhiteNecromant);
            Show(Yanus, PositionOnTheStage.Right);

            await Say(Yanus, "������� ����� � ������ ��� ��� ������� ������. " +
                "���� ������� ������� ���������� ������ � ������ �� �������� ������ ���� ���-�����.", "");

            await Say(Yanus, "� ���������� ������.", "");

            await Say(Skull, "������ ��� ������ � �������� ������� ����� �������.", "");

            await Say(Skull, "���� �� ����, ��� �� ��� ��� ��� ������ � ����� � ��� �� ��������, " +
                "���� �������� ������������� �� ����������. ����� ���������?", "");

            await Say(Yanus, "���� ���, ���� ����� �� ����� ��������� ������� �� ����.", "");

            await Say(Yanus, "���� ����, ����������� ������ ���������, ��� ���� ����������� �������, " +
                "����� ����� ��������� ������.", "");

            await Say(Yanus, "��� ������ �������� � ������ ������� �������� �� ������ �������.", "");

            await Say(Skull, "��� ��� �������� � ����� ��������� ������������ ��������� ���������.", "");

            await Say(Yanus, "��� ������� ����������� ������. " +
                "������� ������� ������� � ������ ������������ ��������� ���� ������ �������������� �������������� ���.", "");

            Fork();
        }
    }
}