using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene14_3_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator LordCarlos = storyInformator.LordCarlos;

            Scene(storyInformator.Office);

            Show(Skull, PositionOnTheStage.Left);
            Show(LordCarlos, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "Мы с радостью примем вашу дочь на обучение, остальное будет зависеть от магии.", "");

            await Say(LordCarlos, "Отлично! Шлем станет платой за ее обучение.", "");

            await Say(Skull, "Даже без порталов у магов ордена Познающих есть чему поучиться.", "");

            Fork();
        }
    }
}