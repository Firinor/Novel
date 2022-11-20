namespace FirGames.StoryPart3
{
    public class P3Scene20 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.TiirRoom);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "“еперь пон€тно почему Ёрмингарда настроена против теб€ - она опасаетс€ мести. " +
                " оролева была врагом твоего отца и эта вражда перешла к тебе по наследству.", "");

            Fork();
        }
    }
}
