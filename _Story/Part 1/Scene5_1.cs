using UnityEngine;

namespace FirGames.StoryPart1
{
    public class Scene5_1 : DialogNode
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

            await Say(Skull, "регент должен заботиться не только о ребенке, но и о стране.", "");

            Fork();
        }
    }
}
