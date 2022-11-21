namespace FirGames.StoryPart4
{
    public class P4Scene6_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.PortalOn);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "За столь явный отказ подчиниться приказу, королева имеет законное право тебя казнить." +
                " Давай помедитируем для спокойствия. Дыши глубже, раз, два, три.", "");

            Fork();
        }
    }
}
