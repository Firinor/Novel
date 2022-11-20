namespace FirGames.StoryPart4
{
    public class P4Scene1_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Vargus = Characters.Vargus;

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Center);
            Show(Vargus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "Не переживай, Варгус, тебя тоже ждет новая должность " +
                "школьного учителя в деревне Нижние Мухоморы.", "");
            await Say(Skull, "Тамошний климат способствует выветриванию эгоцентризма.", "");

            await Say(Vargus, "Вы обо мне еще услышате!", "");

            await Say(Skull, "Надеюсь, отзывы родителей учеников о твоей работе будут хорошими.", "");

            Fork();
        }
    }
}
