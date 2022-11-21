namespace FirGames.StoryPart4
{
    public class P4Scene13 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.Desert);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Честь честью, но воинам нужно платить, поэтому вождь отправил золото. " +
                "Война затянулась, добычи становится меньше.", "");
            await Say(Skull, "Странно что Вацела еще не отозвал своих головорезов. " +
                "Неужели в этот раз он пришел не ограбить, а завоевать Карпатию?", "");
            await Say(Skull, "Как бы то ни было, нам нужно отыскать лагерь герцога Аргуза и предупредить его о золоте.", "");

            Fork();
        }
    }
}
