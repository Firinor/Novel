namespace FirGames.StoryPart3
{
    public class P3Scene6 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.ElvenHut);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Вот и охотничий дом Тиира. Все, как написано: повернуть у третьего пня," +
                " сто шагов от кривой березы. Смотри, на двери замок с кодом. Хозяин явно хочет нас испытать.", "");

            Fork();
        }
    }
}
