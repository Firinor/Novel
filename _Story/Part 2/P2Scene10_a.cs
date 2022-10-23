using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene10_a : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.PortalOff);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "���� ������ �� ����������, ����� � ������ ������� ��� � �������," +
                " ��� ��� ��� ���������. ��������� ������� ��������� ��� ���������.", "");
            await Say(Skull, " ����������, �� � ��� �� ����� � �������� ������," +
                " ���������� �������� �������: ���, ���, ���.", "");

            Fork();
        }
    }
}
