using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene14_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.Castle);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "���������! �� � ����� ������� � ���������� ��� ��������. " +
                "�� ����� ������ ������� ������, � �� ������ ���������. ������� �� ���������!", "");

            Fork();
        }
    }
}