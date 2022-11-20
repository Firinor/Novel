using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Yanus = Characters.Yanus;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Left);
            Show(Yanus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Yanus, "“ы дерзко повел себ€ сегодн€ на поминках.", "");

            await Say(Skull, "Ќе более дерзко, чем ¬аргус, решивший, что пост архимагистра у него в кармане.", "");

            await Say(Yanus, "“вой отец был таким же. ћного лет назад в одной рыбацкой деревне € увидел" +
                " как подросток предупреждал собиравшихс€ выйти в море рыбаков о надвигающейс€ буре.", "");
            await Say(Yanus, "ќни, конечно, ему не поверили и с высоты своего возраста сказали не учить взрослых." +
                " “огда юнец схватил багор и продыр€вил обшивку лодки.", "");
            await Say(Yanus, "¬ ответ на такой поступок старший рыбак очень разозлилс€ и пообещал выпороть парн€," +
                " если бури не будет. ѕодросток оказалс€ прав.", "");
            await Say(Yanus, "“вой отец уже в ранней молодости обладал поразительной наблюдательностью.", "");
            await Say(Yanus, "—воим поступком он спас жизни целой команды рыбаков, в том числе и своему отцу." +
                " ѕроверим, унаследовал ли ты его внимательность.", "");

            Fork();
        }
    }
}