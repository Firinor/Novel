using UnityEngine;

namespace FirGames.StoryPart1
{
    public class P1Scene1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Archmagister = Characters.Archmagister;

            Scene(Backgrounds.Lab);

            Show(Archmagister, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Archmagister, "���� ���, ������ ���� ������ ��������." +
                " ������� �� ��� ������ ���������� ��������� � �� ������ �������������.", "");

            await Say(Archmagister, "��������� ������� ����� ������������ ��������������� ���������� ������ ������," +
                " ����� ������ ������� � ����� ������������ �������� ���� � ����� ����.", "");

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "������� ��� �������! �� ���������� ������ ���� ������� ���� �����������.", "");

            await Say(Archmagister, "�� � ����� �����������.", "");

            await Say(Skull, "��� �������� � ���.", "");

            await Say(Archmagister, "������ � ������ ������� ������ ��� ������� ��������� �������� � �������. �������� ���." +
                " ���� ���, �����, ��� � ������� ����� � ��� ��� ������ ��� ������������.", "");

            Fork();
        }
    }
}