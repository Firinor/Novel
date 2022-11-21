namespace FirGames.StoryPart1
{
    public class P1Scene6 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Yanus = Characters.Yanus;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, " ого € вижу?! „то тебе нужно, вестник смерти?", "");

            Show(Yanus, PositionOnTheStage.Center);

            await SayByName(Yanus, "Ѕелый некромант", "White necromant",
                "ѕриветствую, дит€ мое.", "");

            await Say(Skull, "ј со мной уже не надо здороватьс€, янус? я слышал, " +
                "кресть€не на юго-западе несколькими деревн€ми собирали награду за твою голову.", "");

            Show(Yanus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Yanus, "энергии жизни и смерти как две стороны медали. " +
                "—таи саранчи грозили уничтожить посевы и обречь на голодную смерть весь юго-запад.", "");

            await Say(Yanus, "я согласилс€ помочь.", "");

            await Say(Skull, "только вот вместе с саранчой вымерла цела€ деревн€.", "");

            await Say(Skull, "—уд€ по тому, что ты уже лет сто ходишь в одном и том же балахоне, " +
                "тво€ мудрость попул€рностью не пользуетс€. «ачем пожаловал?", "");

            await Say(Yanus, "дит€ мое, хочу чтобы ты узнал печальную новость от мен€.", "");

            await Say(Yanus, "“вой отец, архимагистр ордена ѕознающих, был убит отравленной стрелой, " +
                "когда начал открывать портал.", "");

            await Say(Yanus, "—ам портал разрушен и сейчас столица отрезана от других городов.", "");

            await Say(Skull, "вот так праздник в честь окончани€ магистратуры обернулс€ поминками.", "");

            await Say(Yanus, "нет времени предаватьс€ скорби. " +
                "Ќастали смутные времена и смерть архимагистра знаменует лишь начало противоборства могущественных сил.", "");

            Fork();
        }
    }
}