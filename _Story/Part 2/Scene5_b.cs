using UnityEngine;

namespace FirGames.StoryPart2
{
    public class Scene5_b : DialogNode
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

            await Say(Skull, "только политике с ее законами есть дело до всех нас.", "");

            Fork();
        }
    }
}