using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene6_a : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Karim = storyInformator.Karim;

            Scene(storyInformator.KarimRoom);

            Show(Karim, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Karim, "Рекомендую подумать еще.", "");

            Fork();
        }
    }
}