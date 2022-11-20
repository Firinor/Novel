using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene6_a : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Karim = Characters.Karim;

            Scene(Backgrounds.KarimRoom);

            Show(Karim, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Karim, "Рекомендую подумать еще.", "");

            Fork();
        }
    }
}