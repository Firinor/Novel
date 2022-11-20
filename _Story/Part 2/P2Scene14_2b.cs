using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene14_2b : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Тебе следовало лучше учить родной язык. " +
                "Карлос сразу распознает подделку, если в тексте будут ошибки.", "");

            Fork();
        }
    }
}