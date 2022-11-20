using UnityEngine;

namespace FirGames.StoryPart1
{
    public class P1Scene2_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Стой! Хватит! Вижу ты настоящий бунтарь и любишь пробовать что-то новое." +
                " Прямо как я до своего преображения.", "");

            Fork();
        }
    }
}
