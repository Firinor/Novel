using UnityEngine;

namespace FirGames.StoryPart2
{
    public class Scene5 : DialogNode
    {
        [SerializeField]
        private CharacterInformator Skull;

        [SerializeField]
        private Sprite Island;

        public override async void StartDialog()
        {
            base.StartDialog();

            Scene(Island);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Король умер, его сын - младенец. Наше будущее зависит от того, кто станет регентом ребенка.", "");

            await Say(Skull, "Королева-мать Эрмингарда в столице, но ей подчиняется лишь горстка солдат.", "");

            await Say(Skull, "Младший брат покойного короля Аргуз командует войском, но сейчас он на границе воюет с орками, " +
                "а до столицы идти больше месяца и то, если дождь дороги не размоет. Соображаешь?", "");

            await Say(Skull, "Вот если бы кто-нибудь из ордена Познающих согласился открыть портал от границы до столицы не " +
                "по расписанию, это могло бы сильно повлиять на расстановку сил.", "");

            await Say(Skull, "Сам как думаешь, из кого получится лучший регент?", "");

            Fork();
        }
    }
}