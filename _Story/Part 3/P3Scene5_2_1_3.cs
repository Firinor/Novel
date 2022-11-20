namespace FirGames.StoryPart3
{
    public class P3Scene5_2_1_3 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.BeginOfElvenForest);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, " огда магистры отказывались передавать свои знани€," +
                " не нашлось никого, кто мог бы их заставить. «аконы посто€нно мен€лись" +
                " и во многом их исполн€емость зависела от личности владыки.", "");

            await Say(Skull, "“иир хочет объединить свой народ. Ѕез сомнени€," +
                " он интересна€ личность, но хватит ли алхимику мудрости выстроить вокруг себ€ целую систему.", "");

            Fork();
        }
    }
}
