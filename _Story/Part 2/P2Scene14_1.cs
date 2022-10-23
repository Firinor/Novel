using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene14_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Castle);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "���������! �� � ����� ������� � ���������� ��� ��������. " +
                "�� ����� ������ ������� ������, � �� ������ ���������. ������� �� ���������!", "");

            Fork();
        }
    }
}