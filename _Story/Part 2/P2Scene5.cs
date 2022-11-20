using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene5 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator GnomGuard = Characters.GnomGuard;

            Scene(Backgrounds.GnomeDoor);

            Show(Skull, PositionOnTheStage.Left);
            Show(GnomGuard, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "�� � ��������� ������ �� �������� ����.", "");

            await Say(GnomGuard, "������� �������� ������!", "");

            Fork();
        }
    }
}