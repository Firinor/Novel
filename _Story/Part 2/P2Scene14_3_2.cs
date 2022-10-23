using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene14_3_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator LordCarlos = storyInformator.LordCarlos;

            Scene(storyInformator.Office);

            Show(Skull, PositionOnTheStage.Left);
            Show(LordCarlos, PositionOnTheStage.Right);

            await Say(Skull, "��������, �� ��� ���������� ������������� ����������.", "");
            await Say(Skull, "���� ������ ��������� ����� ������� ������ ��������� ������������ ������ �������� ��������. " +
                "���� � ����� ������ ��� ���, ��� ������� �� ������ ��������� �������.", "");

            await Say(LordCarlos, "����� ��� �� � ��� �������������.", "");

            await Say(Skull, "������� ������ �������. �������� ������ ��� ����.", "");

            Fork();
        }
    }
}