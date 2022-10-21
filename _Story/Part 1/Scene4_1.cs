using UnityEngine;

namespace FirGames.StoryPart1
{
    public class Scene4_1 : DialogNode
    {
        [SerializeField]
        private CharacterInformator Skull;

        [SerializeField]
        private Sprite Island;

        public override async void StartDialog()
        {
            base.StartDialog();

            Scene(Island);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "���� ��������� - ����������� ��������� ��� ����������� � ��������.", "");

            Fork();
        }
    }
}
