namespace FirGames.StoryPart3
{
    public class P3Scene13 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Voice = storyInformator.Voice;

            Scene(storyInformator.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Стрелы прошли сквозь нас, но не причинили вреда." +
                " Не верь тому, что видишь. Здесь все иллюзия.", "");

            await Say(Voice, "Вы поиграете со мной?", "");

            Fork();
        }
    }
}
