using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Vargus = Characters.Vargus;
            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.Memorial);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "�� �������� ��������� ���, � ������ � �����." +
                " ���� ����������, �������, ������, ������ �������� ������ ����, ���������� � ���� �������.", "");

            await Say(Skull, "�� ������ � ����� ������������ ������ ����," +
                " ������ ����� ������ ��������� ���� � ������ �� ������� ���� � �����.", "");

            HideCharacter(Skull);

            Show(Vargus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Vargus, "������ ������������ ������� ��������, �� ��� ��� ��� �������� ����, �������� � ����������.", "");

            await Say(Vargus, "������� � ����� ��������������� ������� ������, ������������� �� ��� ����� ������ ������.", "");

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "������� ������������ ��� �� ����. �� ���� �� ������� ��� � ����, ����� ��� ��� � �����.", "");

            await Say(Vargus, "���� �� � ����� �������, �� � ���� ������������ �����.", "");

            await Say(Vargus, "����� ����� ����� �������������� ���� ���������," +
                " ����������� �������� ����� ������ �� ����������� ���� ������������� �������?", "");

            HideCharacter(Vargus);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "��� ����� ��� ��������?", "");

            Fork();
        }
    }
}