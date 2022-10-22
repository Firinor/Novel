using UnityEngine;

namespace FirGames.StoryPart1
{
    public class Scene1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Archmagister = storyInformator.Archmagister;

            Sprite Lab = storyInformator.Lab;

            Scene(Lab);

            Show(Archmagister, PositionOnTheStage.Right);

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