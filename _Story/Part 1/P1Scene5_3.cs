using UnityEngine;

namespace FirGames.StoryPart1
{
    public class P1Scene5_3 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "армия как стрела, может защитить, а может убить.", "");

            Fork();
        }
    }
}
