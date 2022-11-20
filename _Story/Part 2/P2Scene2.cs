using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Yanus = Characters.Yanus;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Left);
            Show(Yanus, PositionOnTheStage.Right, ViewDirection.Left);

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