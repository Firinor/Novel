namespace FirGames.StoryPart3
{
    public class P3Scene5_2_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.BeginOfElvenForest);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Перед нами эльфийские земли, ну, или то, что от них осталось." +
                " Легендарные Ушедшие, строители порталов, были эльфами, но за века их раса деградировала, " +
                "многие знания были утрачены.", "");

            await Say(Skull, "Дошло до того, что язык Ушедших для современных эльфов такой же трудный, " +
                "как для нас с тобой. Как думаешь, что послужило причиной упадка эльфийской расы?", "");

            Fork();
        }
    }
}
