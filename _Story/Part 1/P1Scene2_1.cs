using UnityEngine;

namespace FirGames.StoryPart1
{
    public class P1Scene2_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Отлично! Ты умеешь выполнять указания на пути к цели, если так нужно.", "");

            Fork();
        }
    }
}
