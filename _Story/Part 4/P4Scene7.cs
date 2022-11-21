namespace FirGames.StoryPart4
{
    public class P4Scene7 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Mercenary = Characters.Mercenary;

            Show(Mercenary, PositionOnTheStage.Left);
            Show(Skull, PositionOnTheStage.Right, ViewDirection.Right);

            Scene(Backgrounds.DesertPortalOn);

            await Say(Skull, "Ни намека не присутствие людей. Очевидно, орки оттеснили" +
                " войска Аргуза из этой части Карпатии.", "");
            await Say(Skull, "Справится с обученным магом пространства сложно и наши сопровождающие это знают.", "");
            await Say(Skull, "Двое-трое легкая мишень, но сразу двадцать наемников нам не одолеть." +
                " Ох, вот были золотые времена: подписи с печатями, печати с подписями.", "");
            await Say(Skull, "Хочу обратно в уютный кабинет архимагистра. Ладно, поныли и хватит." +
                " Для начала предлагаю осмотреться.", "");

            Fork();
        }
    }
}
