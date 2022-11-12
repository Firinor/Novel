using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene1_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Vargus = storyInformator.Vargus;
            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Memorial);

            Show(Skull, PositionOnTheStage.Left);
            Show(Vargus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Skull, "����������� ������ ��������� ����� �����, � � ��� ����� ���������," +
                " ��� ������ ����� ������ �������� ����� 15 ���� ����� ������ �����������, �� ������.", "");

            await Say(Vargus, "� ���� ������! ����� 15 ����," +
                " ���� ������� ������ �� �������� ������� �������, �� ��������� ������ ��-�������.", "");

            Fork();
        }
    }
}