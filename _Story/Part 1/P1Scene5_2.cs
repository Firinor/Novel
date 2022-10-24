using UnityEngine;

namespace FirGames.StoryPart1
{
    public class P1Scene5_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "только политике с ее законами есть дело до всех нас.", "");

            Fork();
        }
    }
}
