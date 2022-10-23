using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene5 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator GnomGuard = storyInformator.GnomGuard;

            Scene(storyInformator.GnomeDoor);

            Show(Skull, PositionOnTheStage.Left);
            Show(GnomGuard, PositionOnTheStage.Right);

            await Say(Skull, "�� � ��������� ������ �� �������� ����.", "");

            await Say(GnomGuard, "������� �������� ������!", "");

            Fork();
        }
    }
}