using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene13 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Karim = Characters.Karim;

            Scene(Backgrounds.KarimRoom);

            Show(Skull, PositionOnTheStage.Left);
            Show(Karim, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Karim, "Поздравляю! Карлос в вас не ошибся, а я не зря потратил флюорит!", "");

            await Say(Skull, "Вы в большом выигрыше и, я думаю, сейчас самое время поговорить о лаборатории.", "");

            await Say(Karim, "Мы оба в выигрыше. Благодаря восстановленному порталу пост архимагистра у тебя в кармане.", "");
            await Say(Karim, "Мне нравится наше сотрудничество и я готов обсудить условия новой сделки, " +
                "касающейся моей лаборатории.", "");

            await Say(Skull, "Каковы условия?", "");

            await Say(Karim, "Лорд Карлос страстный коллекционер, как и я. В его коллекции находится шлем, " +
                "принадлежащий Богурту Железнозубому, великому воину гномов.", "");
            await Say(Karim, "Полагаю, мое происхождение дает мне больше прав на владение реликвией.", "");

            await Say(Skull, "А если Карлос не согласится отдать шлем?", "");

            await Say(Karim, "Вот стандартная цена за экспертизу в моей лаборатории.", "");

            await Say(Skull, "Ого?! Вы пытаетесь продать нам свою лабораторию со всеми сотрудниками?!", "");

            await Say(Karim, "Срочная работа всегда дорогая.", "");

            await Say(Skull, "Думаю, мы прямо сейчас отправимся к Карлосу.", "");

            await Say(Karim, "Буду ждать новостей.", "");

            Fork();
        }
    }
}