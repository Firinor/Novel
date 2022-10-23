using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Yanus = storyInformator.Yanus;

            Scene(storyInformator.World);

            Show(Skull, PositionOnTheStage.Left);
            Show(Yanus, PositionOnTheStage.Right);

            await Say(Yanus, "�� ������ ����� ���� ������� �� ��������.", "");

            await Say(Skull, "�� ����� ������, ��� ������, ��������, ��� ���� ������������ � ���� � �������.", "");

            await Say(Yanus, "���� ���� ��� ����� ��. ����� ��� ����� � ����� �������� ������� � ������" +
                " ��� ��������� ������������ ������������ ����� � ���� ������� � ������������� ����.", "");
            await Say(Yanus, "���, �������, ��� �� �������� � � ������ ������ �������� ������� �� ����� ��������." +
                " ����� ���� ������� ����� � ���������� ������� �����.", "");
            await Say(Yanus, "� ����� �� ����� �������� ������� ����� ����� ���������� � �������� �������� �����," +
                " ���� ���� �� �����. ��������� �������� ����.", "");
            await Say(Yanus, "���� ���� ��� � ������ ��������� ������� ������������� �����������������.", "");
            await Say(Yanus, "����� ��������� �� ���� ����� ����� ������� �������, � ��� ����� � ������ ����." +
                " ��������, ����������� �� �� ��� ��������������.", "");

            Fork();
        }
    }
}