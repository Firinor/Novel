namespace FirGames.StoryPart3
{
    public class P3Scene9 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Tiir = Characters.Tiir;

            Scene(Backgrounds.ElvenPalace);

            Show(Skull, PositionOnTheStage.Left);
            Show(Tiir, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Tiir, "Мы пришли.", "");

            await Say(Skull, "Пирамида?", "");

            await Say(Tiir, "Попробуйте сделать еще шаг.", "");

            await Say(Skull, "...", "");
            await Say("БАХ!", "");

            await Say(Skull, "Я чуть не разбил свой череп!", "");

            await Say(Tiir, "Невидимый барьер очень сильный.", "");

            await Say(Skull, "Против магии порталов такой барьер бесполезен. Приступим к строительству.", "");

            Fork();
        }
    }
}
