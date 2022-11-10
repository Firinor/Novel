namespace FirGames.StoryPart3
{
    public class P3Scene1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Castle);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Осторожно! Мы в замке Карлоса и собираемся его ограбить. " +
                "За одной дверью комната охраны, а за другой хранилище. Главное не ошибиться!", "");

            Fork();
        }
    }
}
