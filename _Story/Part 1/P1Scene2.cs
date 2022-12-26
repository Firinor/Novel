namespace FirGames.StoryPart1
{
    public class P1Scene2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.World);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Очень странно, что архимагистр ордена Познающих сам пошел открывать портал для какого-то каравана," +
                " когда есть целая команда таких как ты. ", "");

            await Say(Skull, "Хотя в наше неспокойное время, после смерти короля, никому нельзя доверять." +
                " Для начала проверим базовые знания.", "");

            await Say(Skull, "Создай мне сферу силы стандартного радиуса огненно-рыжего цвета с алыми вкраплениями.", "");

            Fork();
        }
    }
}