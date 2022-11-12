namespace FirGames.StoryPart3
{
    public class P3Scene5_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.FirePlace);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "“оже правильно. янус любит сказать много и не сказать ничего, он нас только запутает." +
                " ≈сли бы “иир хотел причинить нам вред, он бы это уже сделал.", "");

            Fork();
        }
    }
}
