using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene9 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Karim = Characters.Karim;

            Scene(Backgrounds.Quarry);

            Show(Skull, PositionOnTheStage.Left);
            Show(Karim, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "Большое спасибо. Еще у нас есть просьба касательно лаборатории.", "");

            await Say(Karim, "Прежде чем дать свой ответ на какую-либо просьбу " +
                "я должен убедиться в выгоде нашего сотрудничества.", "");

            await Say(Skull, "Тогда мы сию же секунду идем строить портал.", "");

            await Say(Karim, "Удачи. Она вам понадобиться.", "");

            await ShowImage(SpecialImages.TwoDaysHavePassed);

            Fork();
        }
    }
}