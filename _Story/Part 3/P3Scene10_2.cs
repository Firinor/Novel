namespace FirGames.StoryPart3
{
    public class P3Scene10_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.PortalOn);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "У нас нет выбора. Либо станем друзьями этого сумасшедшего," +
                " либо его подопытными. Если убьет - это надолго, если превратит в идиотов - это навсегда.", "");

            await Say(Skull, "Теперь успокойся и давай помедитируем. Дыши глубже. Раз, два, три.", "");

            Fork(soloButton: true);
        }
    }
}
