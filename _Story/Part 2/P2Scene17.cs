namespace FirGames.StoryPart2
{
    public class P2Scene17 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Lab);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Основной компонент яда сделан из редкого растения, которое произрастает " +
                "только на территории эльфийского леса. Это очень странно, поскольку эльфы пацифисты.", "");
            await Say(Skull, "Ума не приложу, что могло заставить их покуситься на жизнь твоего отца. " +
                "Интуиция подсказывает, что в этом деле все не так просто.", "");

            Fork();
        }
    }
}