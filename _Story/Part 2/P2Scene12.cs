using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene12 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.PortalOn);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "�� ���� �������� ������ ������ �������, �� ���� �������� ���� �����," +
                " �� ������� ��� ������ ������ ����.", "");
            await Say(Skull, "�� ��� ����� �� �� ������ ����������. ���� �� ����� ������ ������, " +
                "����� ������ ��������� � ������ � ������� � ���� ������ � �����������.", "");

            Fork();
        }
    }
}
