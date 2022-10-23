using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene7 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Karim = storyInformator.Karim;

            Scene(storyInformator.KarimRoom);

            Show(Karim, PositionOnTheStage.Center);

            await Say(Karim, "������, � ������ ��� � ������.", "");

            Fork();
        }
    }
}