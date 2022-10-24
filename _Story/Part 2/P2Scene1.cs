using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Varus = storyInformator.Varus;
            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Memorial);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "�� �������� ��������� ���, � ������ � �����." +
                " ���� ����������, �������, ������, ������ �������� ������ ����, ���������� � ���� �������.", "");

            await Say(Skull, "�� ������ � ����� ������������ ������ ����," +
                " ������ ����� ������ ��������� ���� � ������ �� ������� ���� � �����.", "");

            Hide(Skull);

            Show(Varus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Varus, "������ ������������ ������� ��������, �� ��� ��� ��� �������� ����, �������� � ����������.", "");

            await Say(Varus, "������� � ����� ��������������� ������� ������, ������������� �� ��� ����� ������ ������.", "");

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "������� ������������ ��� �� ����. �� ���� �� ������� ��� � ����, ����� ��� ��� � �����.", "");

            await Say(Varus, "���� �� � ����� �������, �� � ���� ������������ �����.", "");

            await Say(Varus, "����� ����� ����� �������������� ���� ���������," +
                " ����������� �������� ����� ������ �� ����������� ���� ������������� �������?", "");

            Hide(Varus);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "��� ����� ��� ��������?", "");

            Fork();
        }
    }
}