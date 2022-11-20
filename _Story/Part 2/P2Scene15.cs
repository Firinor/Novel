using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene15 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Ура! Шлем у нас. Скорее вернемся к Кариму.", "");

            Fork();
        }
    }
}