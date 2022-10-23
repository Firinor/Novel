using UnityEngine;

namespace FirGames.StoryPart1
{
    public class P1Scene6 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator WhiteNecromant = storyInformator.WhiteNecromant;
            CharacterInformator Yanus = storyInformator.Yanus;

            Scene(storyInformator.World);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Кого я вижу?! Что тебе нужно, вестник смерти?", "");

            Show(WhiteNecromant, PositionOnTheStage.Right);

            await Say(WhiteNecromant, "приветствую, дитя мое.", "");

            await Say(Skull, "А со мной уже не надо здороваться, Янус? Я слышал, " +
                "крестьяне на юго-западе несколькими деревнями собирали награду за твою голову.", "");

            Hide(WhiteNecromant);
            Show(Yanus, PositionOnTheStage.Right);

            await Say(Yanus, "энергии жизни и смерти как две стороны медали. " +
                "Стаи саранчи грозили уничтожить посевы и обречь на голодную смерть весь юго-запад.", "");

            await Say(Yanus, "Я согласился помочь.", "");

            await Say(Skull, "только вот вместе с саранчой вымерла целая деревня.", "");

            await Say(Skull, "Судя по тому, что ты уже лет сто ходишь в одном и том же балахоне, " +
                "твоя мудрость популярностью не пользуется. Зачем пожаловал?", "");

            await Say(Yanus, "дитя мое, хочу чтобы ты узнал печальную новость от меня.", "");

            await Say(Yanus, "Твой отец, архимагистр ордена Познающих, был убит отравленной стрелой, " +
                "когда начал открывать портал.", "");

            await Say(Yanus, "Сам портал разрушен и сейчас столица отрезана от других городов.", "");

            await Say(Skull, "вот так праздник в честь окончания магистратуры обернулся поминками.", "");

            await Say(Yanus, "нет времени предаваться скорби. " +
                "Настали смутные времена и смерть архимагистра знаменует лишь начало противоборства могущественных сил.", "");

            Fork();
        }
    }
}