using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene16 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Karim = storyInformator.Karim;

            Scene(storyInformator.KarimRoom);

            Show(Skull, PositionOnTheStage.Left);
            Show(Karim, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Karim, "Это действительно шлем Богурта Железнозубого. Я всегда держу слово." +
                " Лаборатория в вашем распоряжении.", "");

            await Say(Skull, "Приступим к делу, пока не стало поздно.", "");

            Fork();
        }
    }
}