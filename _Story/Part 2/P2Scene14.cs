using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene14 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "� ��� ��� ������� ����� ���� �� �������� � ��������� ����������" +
                " � ������� �������� ����������.", "");
            await Say(Skull, "���� ��������� �������� ������� ���� ������ ������������� �� ��������� �������." +
                " ���� ������, ��� ����� ���������.", "");

            Fork();
        }
    }
}