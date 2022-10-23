using UnityEngine;

namespace FirGames.StoryPart1
{
    public class P1Scene2_1 : DialogNode
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

            await Say(Skull, "Отлично! Ты умеешь выполнять указания на пути к цели, если так нужно.", "");

            Fork();
        }
    }
}
