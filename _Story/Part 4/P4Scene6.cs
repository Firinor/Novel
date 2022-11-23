namespace FirGames.StoryPart4
{
    public class P4Scene6 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Mercenary = Characters.Mercenary;

            Scene(Backgrounds.PortalOn);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Мы снова у портала. Когда мы войдем туда, твоя жизнь окажется в опасности.", "");
            await Say(Skull, "После убийства предыдущего архимагистра, Эрмингарда опасается действовать открыто," +
                " поэтому отправила с нами двадцать наемных убийц.", "");

            Show(Mercenary, PositionOnTheStage.Right);

            await Say(Skull, "Карпатия спорная территория, где постоянно идут бои." +
                " Никого не удивит, если ты оттуда не вернешься.", "");

            Fork();
        }
    }
}
