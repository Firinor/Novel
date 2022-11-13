namespace FirGames.StoryPart3
{
    public class P3Scene4 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Tiir = storyInformator.Tiir;

            Scene(storyInformator.Fun);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Как это понимать?! Варгус и охранники играют в классики?! А это кто?!", "");

            Show(Tiir, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Tiir, "Не стоит волноваться. Тот, кого вы назвали Варгус," +
                " и стражники находятся в состоянии высшего блаженства.", "");

            await Say(Skull, "Ты кто такой?", "");

            await Say(Tiir, "Мое имя Тиир, я алхимик, слуга народа эльфов.", "");

            await Say(Skull, "Алхимик? Тогда понятно.", "");

            await Say(Tiir, "С помощью зелья блаженства можно пройти куда угодно.", "");

            await Say(Tiir, "Охрана будет так занята играми с радужными единорогами и танцами бабочек," +
                " но не запомнит кто приходил.", "");

            await Say(Tiir, "Не бойтесь, зелье безвредно, даже головной боли не будет.", "");

            await Say(Skull, "Что вам нужно, господин алхимик?", "");

            await Say(Tiir, "Есть важное дело, касающееся моего народа," +
                " но я не желаю обсуждать этот вопрос здесь, где стены могут иметь уши.", "");

            await Say(Tiir, "Скажу только, что строительство порталов должно очень хорошо оплачиваться. " +
                "Если интересно, приходи в мой охотничий домик. Вот карта.", "");

            await Say(Skull, "Мы подумаем.", "");

            await Say(Tiir, "Разумеется. Действие моего зелья продлится еще полчаса.", "");

            await Say(Tiir, "Можете позабавиться, приделать своему Варгусу оленьи рога," +
                " покрасить в сиреневый или переодеть в балетную пачку. Он не запомнит, что это были вы.", "");

            await Say(Skull, "Заманчиво. Как мы поступим?", "");

            Fork();
        }
    }
}
