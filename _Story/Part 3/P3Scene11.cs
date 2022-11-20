namespace FirGames.StoryPart3
{
    public class P3Scene11 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Я чувствую здесь магическую энергию в огромной концентрации." +
                " Одно неверное заклинание и мы взлетим на воздух вместе с хранилищем и половиной эльфийского леса.", "");

            Fork();
        }
    }
}
