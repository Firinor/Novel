using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene9 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Karim = storyInformator.Karim;

            Scene(storyInformator.Quarry);

            Show(Skull, PositionOnTheStage.Left);
            Show(Karim, PositionOnTheStage.Right);

            await Say(Skull, "������� �������. ��� � ��� ���� ������� ���������� �����������.", "");

            await Say(Karim, "������ ��� ���� ���� ����� �� �����-���� ������� " +
                "� ������ ��������� � ������ ������ ��������������.", "");

            await Say(Skull, "����� �� ��� �� ������� ���� ������� ������.", "");

            await Say(Karim, "�����. ��� ��� ������������.", "");

            Fork();
        }
    }
}