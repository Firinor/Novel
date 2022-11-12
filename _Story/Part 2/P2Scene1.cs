using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Vargus = storyInformator.Vargus;
            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Memorial);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "�� �������� ��������� ���, � ������ � �����." +
                " ���� ����������, �������, ������, ������ �������� ������ ����, ���������� � ���� �������.", "");

            await Say(Skull, "�� ������ � ����� ������������ ������ ����," +
                " ������ ����� ������ ��������� ���� � ������ �� ������� ���� � �����.", "");

            Hide(Skull);

            Show(Vargus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Vargus, "������ ������������ ������� ��������, �� ��� ��� ��� �������� ����, �������� � ����������.", "");

            await Say(Vargus, "������� � ����� ��������������� ������� ������, ������������� �� ��� ����� ������ ������.", "");

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "������� ������������ ��� �� ����. �� ���� �� ������� ��� � ����, ����� ��� ��� � �����.", "");

            await Say(Vargus, "���� �� � ����� �������, �� � ���� ������������ �����.", "");

            await Say(Vargus, "����� ����� ����� �������������� ���� ���������," +
                " ����������� �������� ����� ������ �� ����������� ���� ������������� �������?", "");

            Hide(Vargus);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "��� ����� ��� ��������?", "");

            Fork();
        }
    }
}