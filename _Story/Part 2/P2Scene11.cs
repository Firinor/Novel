using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene11 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.PortalOn);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Надо же! Работает! Конечно, не то чтобы я сомневался, так слегка волновался.", "");
            await Say(Skull, "Поздравляю, ты уже не начинающий маг, а уважаемый инженер порталов." +
                " Очень скоро тобой начнут интересоваться все враждующие фракции.", "");

            Fork();
        }
    }
}