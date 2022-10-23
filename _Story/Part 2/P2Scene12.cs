using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene12 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.PortalOn);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Не хочу омрачать момент нашего триумфа, но даже учитывая твой успех," +
                " до выборов еще больше десяти дней.", "");
            await Say(Skull, "За это время яд на стреле распадется. Если мы хотим узнать правду, " +
                "нужно скорее вернуться к Кариму и просить у него доступ в лабораторию.", "");

            Fork();
        }
    }
}
