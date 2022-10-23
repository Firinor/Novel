using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene10 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.PortalOff);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Карлос сдержал слово и нам никто не мешает. Хотя, возможно, все гораздо проще. " +
                "Варгус и королева не верят в наш успех и хотят понаблюдать как мы опозоримся. Начинаем испытание?", "");

            Fork();
        }
    }
}