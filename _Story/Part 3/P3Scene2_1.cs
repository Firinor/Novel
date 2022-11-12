namespace FirGames.StoryPart3
{
    public class P3Scene2_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Vargus = storyInformator.Vargus;

            Scene(storyInformator.FirePlace);

            Show(Skull, PositionOnTheStage.Left);
            Show(Vargus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Skull, "Приказ, подписи, печать - все верно. Мы подчиняется.", "");

            await Say(Vargus, "Неужели я слышу в ваших словах намек на мудрость?!", "");

            Fork();
        }
    }
}
