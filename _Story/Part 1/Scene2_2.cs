using UnityEngine;

namespace FirGames.StoryPart1
{
    public class Scene2_2 : DialogNode
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

            await Say(Skull, "Стой! Хватит! Вижу ты настоящий бунтарь и любишь пробовать что-то новое." +
                " Прямо как я до своего преображения.", "");

            Fork();
        }
    }
}
