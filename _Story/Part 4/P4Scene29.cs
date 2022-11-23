namespace FirGames.StoryPart4
{
    public class P4Scene29 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;
            CharacterInformator Arguz = Characters.Arguz;

            Scene(Backgrounds.CommanderInChiefsTent);

            Show(Bathyard, PositionOnTheStage.Left);
            Show(Skull, PositionOnTheStage.Left);
            Show(Arguz, PositionOnTheStage.Right);

            await Say(Arguz, "Что ответил великий вождь Вацела?", "");

            await Say(Bathyard, "Отец принял твое предложение, но Хурга нас предал.", "");

            await Say(Skull, "Есть план. Хурга рассчитывает застигнуть нас врасплох. " +
                "Оставим в лагере соломенные чучела. Как только Хурга войдет в лагерь, ловушка захлопнется.", "");

            await Say(Arguz, "Скорее. Медлить нельзя.", "");

            await ShowImage(SpecialImages.TwoDaysHavePassed);

            Fork();
        }
    }
}
