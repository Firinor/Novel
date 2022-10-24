using UnityEngine;

namespace FirGames.StoryPart1
{
    public class P1Scene4_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Твое испытание - внимательно выслушать мои рассуждения о политике.", "");

            Fork();
        }
    }
}
