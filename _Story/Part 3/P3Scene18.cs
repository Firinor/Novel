namespace FirGames.StoryPart3
{
    public class P3Scene18 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.AtElvenPalace2);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Все прекратилось, теперь мы в каменном зале. " +
                "Только не думаю что пирамида действительно пустая.", "");

            await Say(Skull, "Полагаю, заколдованные камни способны не только накапливать энергию, " +
                "но и сохранять информацию. А вот как ее извлекать знали только Ушедшие.", "");

            await Say(Skull, "Мы отключили защиту и сейчас можно легко открыть хранилище," +
                " но тогда придется поделиться нашими открытиями с Тииром.", "");

            await Say(Skull, "Или можем построить портал, как обещали, а дальше пусть сам разбирается.", "");

            Fork();
        }
    }
}
