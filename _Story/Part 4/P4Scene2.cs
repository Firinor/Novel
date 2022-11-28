namespace FirGames.StoryPart4
{
    public class P4Scene2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Yanus = Characters.Yanus;

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Left);
            Show(Yanus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Yanus, "—удьба ¬аргуса лишь первое из череды решений, " +
                "последстви€ которых будут преследовать теб€ многие годы.", "");

            await Say(Skull, "я знаю, что по специализации ты некромант, но, " +
                "просто дл€ разнообрази€, скажи что-нибудь не мрачное.", "");

            await Say(Yanus, "ѕоздравл€ю с должностью. ѕомни, что чем выше взлетаешь, тем больнее падать.", "");

            Fork();
        }
    }
}
