using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene10_a : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.PortalOff);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Если портал не заработает, Карим и Карлос возьмут нас в рабство," +
                " так что без вариантов. Предлагаю технику медитации для храбрости.", "");
            await Say(Skull, " Расслабься, ни о чем не думай и мысленно считай," +
                " постепенно замедляя дыхание: раз, два, три.", "");

            Fork();
        }
    }
}
