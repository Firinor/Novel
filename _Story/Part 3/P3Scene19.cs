namespace FirGames.StoryPart3
{
    public class P3Scene19 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Tiir = storyInformator.Tiir;

            Scene(storyInformator.TiirRoom);

            Show(Skull, PositionOnTheStage.Left);
            Show(Tiir, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Tiir, "Я узнал то, о чем вы просили. По приказу королевы Эрмингарды" +
                " ее слуги украли растения и сделали яд, чтобы подставить мой народ.", "");

            await Say(Tiir, "Твой отец поддерживал герцога Аргуза, дядю вашего короля-младенца, в борьбе за регентство.", "");

            await Say(Tiir, "Покойный архимагистр собирался открыть портал от приграничных земель до столицы," +
                " чтобы герцог быстро провел свои войска и захватил власть.", "");

            await Say(Tiir, "Эрмингарда в ответ решила устранить нелояльного мага порталов.", "");

            await Say(Skull, "Как ты это выяснил?", "");

            await Say(Tiir, "Ближайшая помощница королевы сама мне все рассказала." +
                " Я уверен в том, что она говорила правду и в том, что она меня не запомнила.", "");

            await Say(Skull, "Опять чудо-настойки? Не взыщи, если после таких признаний мы откажемся от приглашения на ужин.", "");

            await Say(Tiir, "Теперь мы связаны нитями судьбы. Возьми это зеркало. У меня есть такое же. " +
                "Произнеси заклинание и я тебя услышу, не важно как велико расстояние между нами.", "");

            await Say(Skull, "Удобно.", "");

            await Say(Tiir, "До встречи. Не забудь позвать на праздник, когда станешь архимагистром ордена Познающих.", "");

            Fork();
        }
    }
}
