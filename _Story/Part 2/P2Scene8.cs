using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene8 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Karim = storyInformator.Karim;

            Scene(storyInformator.Quarry);

            Show(Skull, PositionOnTheStage.Left);
            Show(Karim, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Karim, "Вот и карьер. Берите сколько нужно по смете и ни кристаллом больше.", "");

            await Say(Skull, "Хорошо что я завысил нужное число флюорита в смете. " +
                "Как говориться, ложь не является ложью, пока кто-то не узнает правду.", "");

            Fork();
        }
    }
}