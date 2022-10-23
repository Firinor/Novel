using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene14_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Карлос готов на многое, чтобы угодить королеве.", "");
            await Say(Skull, "Напишем письмо якобы от королевы Эрмингарды с просьбой передать шлем в королевскую сокровищницу. " +
                "Притворимся ее слугами и люди Карлоса сами принесут нам шлем.", "");

            Fork();
        }
    }
}