using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene14_3_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator LordCarlos = storyInformator.LordCarlos;

            Scene(storyInformator.Office);

            Show(Skull, PositionOnTheStage.Left);
            Show(LordCarlos, PositionOnTheStage.Right);

            await Say(Skull, "—ожалеем, но дар управлени€ пространством врожденный.", "");
            await Say(Skull, "ћаги ордена ѕознающих могут научить только правильно пользоватьс€ данным природой талантом. " +
                "≈сли у вашей дочери его нет, она никогда не сможет открывать порталы.", "");

            await Say(LordCarlos, "“огда нам не о чем разговаривать.", "");

            await Say(Skull, "„естна€ дорога закрыта. ќсталось только два пути.", "");

            Fork();
        }
    }
}