using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene1_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Varus = storyInformator.Varus;
            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Memorial);

            Show(Skull, PositionOnTheStage.Left);
            Show(Varus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Skull, "�� ������ ������������ �� ����� ��������� ������������," +
                " �� ���� �� ����� ������ ������ ���� �� �������� ���� ������������ � ��� ������!", "");

            await Say(Varus, "� �� ��������� ������������ ����� �������� ������� � ����������!" +
                " �� ������ ������ ������������ �������� ����� 15 ���� ����� ������ �����������.", "");

            await Say(Varus, "��� ������ � ����� �����, ������� �� ����� ���, �� �������� ���� � �����," +
                " � �������� ������� ���� ������ �������� � ������ �� ������ �� �������!", "");

            Fork();
        }
    }
}