namespace FirGames.StoryPart3
{
    public class P3Scene15 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Voice = storyInformator.Voice;

            Scene(storyInformator.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Voice, "Дайте же мне поспать!", "");

            await Say(Skull, "Тигр! Прячься! Стоп, он же иллюзия. Но как натурально!" +
                " Если бы у меня было сердце, оно бы остановилось.", "");

            await Say(Voice, "Давайте еще в загадки поиграем?", "");

            Fork();
        }
    }
}
