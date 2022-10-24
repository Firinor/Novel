using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene4 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator LordCarlos = storyInformator.LordCarlos;

            Scene(storyInformator.Office);

            Show(Skull, PositionOnTheStage.Left);
            Show(LordCarlos, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(LordCarlos, "������ �� ��� ������������� ������� ���, ����������," +
                " ��� ������� ������� ����� �� ������ ���������, �� � �������?", "");

            await Say(Skull, "��� ��� ������ � ��������� ����� ���. ����� ������ ���������� ��������." +
                " ���, ��������� �� �������.", "");

            await Say(LordCarlos, "�������?! ����� ����� ��������� ������ �������, ������� ������.", "");
            
            await Say(Skull, "������ � ��� ����������. ���� � �������, �� �������, ��� ������," +
                " � ���� � �������� �� - �� ���������� �������, �� ��� ������� � ���� �����.", "");
            await Say(Skull, "��� � ����� �������� � ������������� �������� � ����� ���������.", "");

            await Say(LordCarlos, "��� �����, �� �����. �� ���������� ������� ���������� ��� ���������, �� ���� ��� � ��������.", "");
            await Say(LordCarlos, "�������� ���������� ���������, ��� ������ ����� �������� ������ ����� ������," +
                " � � �� ���� � ��� ��������, ������� �� ���� ����������� ���� ������� � �������������� �������.", "");
            await Say(LordCarlos, "������ � ���� ������ ��� � �������. �� ��������� ����-��������," +
                " � ����� �������� �������, ��� ���� �������.", "");
            await Say(LordCarlos, "����� ��������� �� ������ ��������� � ��������� � ��� ���������." +
                " ���������� �� ������� ���������� ������������� ������, ����� �� ��������� �����������.", "");

            await Say(Skull, "� ������ � ������. � ���� � ������������ ���� ���� �� ������ ���������� �����������." +
                " ��� ���������� ����� �������������.", "");

            await Say(LordCarlos, "������ ����� ����� � ��� ��������, �������, ��� ������ �������� ������.", "");

            Fork();
        }
    }
}