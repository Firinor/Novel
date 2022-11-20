namespace FirGames.StoryPart3
{
    public class P3Scene13 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Voice = Characters.Voice;

            Scene(Backgrounds.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Стрелы прошли сквозь нас, но не причинили вреда." +
                " Не верь тому, что видишь. Здесь все иллюзия.", "");

            await Say(Voice, "Вы поиграете со мной?", "");

            Fork();
        }
    }
}
