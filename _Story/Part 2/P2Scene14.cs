using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene14 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "У нас нет времени ждать пока ты вступишь в отцовское наследство" +
                " и сможешь оплатить экспертизу.", "");
            await Say(Skull, "Есть несколько способов достать шлем Борана Железнозубого из коллекции Карлоса." +
                " Тебе решать, как лучше поступить.", "");

            Fork();
        }
    }
}