namespace FirGames.StoryPart4
{
    public class P4Scene19_b : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.CommanderInChiefsTent);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, " онечно, все периодически ошибаютс€, но, хорошо, что " +
                "здесь нет студентов ордена ѕознающих, а то бы засме€ли.", "");

            Fork();
        }
    }
}
