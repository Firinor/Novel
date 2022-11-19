namespace FirGames.StoryPart4
{
    public class P4Scene12 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator MagicianElector = storyInformator.MagicianElector;
            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Vargus = storyInformator.Vargus;

            Scene(storyInformator.FirePlace);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Настал день выборов нового архимагистра. " +
                "Мы сделали все, что могли, остается ждать решения.", "");

            HideCharacter(Skull);

            Scene(storyInformator.Lab);

            Show(MagicianElector, PositionOnTheStage.Center);

            await Say(MagicianElector, "Все проголосовали. Братья и сестры, " +
                "желает ли кто-нибудь высказаться перед тем как я оглашу результаты?", "");

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Молчат.", "");

            HideCharacter(Skull);

            await Say(MagicianElector, "Отлично. Ни у кого нет возражений. " +
                "Приветствуйте нашего нового архимагистра - инженера порталов, достойного сына своего отца.", "");

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Это он тебе. Давай на трибуну! " +
                "Я ни капельки не сомневался, что они примут правильное решение!", "");

            Show(Vargus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Vargus, "Ты не имеешь права там стоять! К какому обману вы, мошенники, прибегли на этот раз?", "");

            await Say(Skull, "Вот и первое решение в новой должности наметилось. Как ты поступишь?", "");

            Fork();
        }
    }
}
