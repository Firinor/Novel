using UnityEngine;

namespace FirGames.StoryPart2
{
    public class Scene4 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Yanus = storyInformator.Yanus;

            Scene(storyInformator.Memorial);

            Show(Skull, PositionOnTheStage.Left);
            Show(Yanus, PositionOnTheStage.Right);

            await Say(Skull, "Я и не сомневался в твоих способностях. У тебя есть выбор:" +
                " пройти следующее очень-очень сложное испытание или выслушать рассуждения старой черепушки о политике.", "");

            Fork();
        }
    }
}