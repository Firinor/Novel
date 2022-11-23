namespace FirGames.StoryPart4
{
    public class P4Scene25 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.OrcEncampment);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Похоже вождь не слишком-то доверяет своему полководцу Хурге," +
                " поэтому отправляет за золотом сына. Интересные у них тут отношения.", "");

            await ShowImage(SpecialImages.TwoDaysHavePassed);

            Fork();
        }
    }
}
