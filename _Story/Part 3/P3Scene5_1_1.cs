namespace FirGames.StoryPart3
{
    public class P3Scene5_1_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Guard = Characters.HumanGuard;

            Scene(Backgrounds.Prison);

            Show(Skull, PositionOnTheStage.Left);
            Show(Guard, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Guard, "Вы к кому?", "");

            await Say(Skull, "Некромант Янус здесь?", "");

            await Say(Guard, "Да, не замолкает со вчерашнего дня.", "");

            await Say(Skull, "Можно его увидеть?", "");

            await Say(Skull, "Мы с ребятами сегодня полдня думаем над задачкой." +
                " Помогите разгадать и я вас пропущу.", "");

            Fork();
        }
    }
}
