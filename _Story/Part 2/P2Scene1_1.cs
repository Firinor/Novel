using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene1_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Varus = storyInformator.Varus;
            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Memorial);

            Show(Skull, PositionOnTheStage.Left);
            Show(Varus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Skull, "Ты всегда заглядывался на место покойного архимагистра," +
                " но тебе не стать главой ордена пока не докажешь свою невиновность в его смерти!", "");

            await Say(Varus, "Я не собираюсь отчитываться перед летающим черепом и недорослем!" +
                " По обычаю выборы архимагистра проходят через 15 дней после смерти предыдущего.", "");

            await Say(Varus, "Как только я займу место, которое по праву мое, то отправлю тебя в архив," +
                " а молодого наглеца лишу звания магистра и выгоню из ордена за клевету!", "");

            Fork();
        }
    }
}