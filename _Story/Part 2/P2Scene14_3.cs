using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene14_3 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator LordCarlos = storyInformator.LordCarlos;

            Scene(storyInformator.Office);

            Show(Skull, PositionOnTheStage.Left);
            Show(LordCarlos, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(LordCarlos, "Я правильно понял, ты просишь меня отдать шлем Богурта Железнозубого Кариму " +
                "потому что хочешь воспользоваться его лабораторией и раскрыть тайну убийства своего отца?", "");

            await Say(Skull, "Правильно.", "");

            await Say(LordCarlos, "Понимаю и одобряю. Я отдам тебе шлем, но взамен попрошу о небольшой услуге. " +
                "Научи мою дочь открывать порталы.", "");

            await Say(Skull, "Что ему ответить? Дар открывать порталы врожденный и у дочери Карлоса его нет.", "");

            Fork();
        }
    }
}