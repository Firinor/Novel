namespace FirGames.StoryPart3
{
    public class P3Scene14 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Voice = storyInformator.Voice;

            Scene(storyInformator.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Voice, "Мы все пленники собственных иллюзий." +
                " Чтобы расстаться с иллюзиями, нужно обнаружить их источник и поступить с ним по разумению.", "");

            await Say(Skull, "Манера речи как у Януса. Некромант что и здесь успел побывать?", "");

            Fork();
        }
    }
}
