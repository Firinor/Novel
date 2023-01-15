namespace FirGames.StoryPart4
{
    public class P4Scene31 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;
            CharacterInformator Arguz = Characters.Arguz;

            Scene(Backgrounds.OrcCamp);

            Show(Bathyard, PositionOnTheStage.Left);
            Show(Skull, PositionOnTheStage.Center, ViewDirection.Right);
            Show(Arguz, PositionOnTheStage.Right);

            await Say(Arguz, "Теперь, когда предатель мертв, почему бы нам не отпраздновать заключение мира?", "");

            await Say(Bathyard, "С удовольствием.", "");

            await Say(Skull, "Если людская пища слишком нежна для вашего желудка, можем наломать камней.", "");

            await Say(Bathyard, "Предпочитаю черепа.", "");

            await Say(Skull, "Вы так остроумны. Полечу посмотрю, что происходит в том дальнем углу.", "");

            await ShowImage(Backgrounds.TwoDaysHavePassed);

            Fork();
        }
    }
}
