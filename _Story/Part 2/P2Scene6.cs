using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene6 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Karim = storyInformator.Karim;

            Scene(storyInformator.KarimRoom);

            Show(Skull, PositionOnTheStage.Left);
            Show(Karim, PositionOnTheStage.Right);

            await Say(Karim, "Приветствую вас!", "");

            await Say(Skull, "Карлос передает привет.", "");

            await Say(Karim, "Да, он говорил мне о талантливом маге-инженере с чертежом портала," +
                " но грамотный делец ведет переговоры только если уверен, что получит прибыль.", "");

            await Say(Skull, "Бесплатные проходы караванов через портал достаточно прибыльны.", "");

            await Say(Karim, "Маленькая подпись всегда ведёт к большому риску. " +
                "У вас есть право подписи для такой сделки?", "");

            await Say(Skull, "Перед вами наследник архимагистра.", "");

            await Say(Karim, "Но пока еще не сам архимагистр.", "");

            await Say(Skull, "Возможность никого не ждет.", "");

            await Say(Karim, "Чем опаснее дорога, тем больше прибыль. Но перед тем как я вложу хоть грамм флюорита, " +
                "я должен проверить, что у вас, молодой изобретатель, кроме богатой фантазии есть еще и логика.", "");

            Fork();
        }
    }
}