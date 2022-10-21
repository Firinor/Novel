using UnityEngine;

namespace FirGames.StoryPart1
{
    public class Scene1 : DialogNode
    {
        [SerializeField]
        private CharacterInformator Skull;
        [SerializeField]
        private CharacterInformator Archmagister;

        [SerializeField]
        private Sprite Lab;

        public override async void StartDialog()
        {
            base.StartDialog();

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