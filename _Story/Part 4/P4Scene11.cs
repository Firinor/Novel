namespace FirGames.StoryPart4
{
    public class P4Scene11 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Nogation = Characters.Nogation;

            Show(Skull, PositionOnTheStage.Center);

            Scene(Backgrounds.Tents);

            await Say(Skull, "Теперь займемся пленным орком.", "");

            Show(Nogation, PositionOnTheStage.Left);

            await SayByName(Nogation, "Орк", "Orc",
                "Я готов умереть, но не готов сдаться!", "");

            await Say(Skull, "Этот выдержит любые пытки, даже твое пенье. " +
                "Тиир подарил тебе флакон своего зелья правды.", "");
            await Say(Skull, "Испробуем на орке. Так, на футляре шифр. Тиир в своем репертуаре.", "");

            Fork();
        }
    }
}
