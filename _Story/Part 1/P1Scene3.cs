using UnityEngine;

namespace FirGames.StoryPart1
{
    public class P1Scene3 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "“ы отличный хранитель знаний," +
                " но все же будь осторожнее со своей безумной теорией о том, что портал ”шедших можно воссоздать.", "");

            await Say(Skull, "ћаги ордена ѕознающих могут открывать древние порталы, " +
                "но построить работающий портал еще никому не удавалось. “еперь проверим знани€ алхимии.", "");

            Fork();
        }
    }
}
