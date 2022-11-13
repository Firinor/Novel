namespace FirGames.StoryPart3
{
    public class P3Scene12 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Voice = storyInformator.Voice;

            Scene(storyInformator.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Симпатичное дерево. Интересно, как оно растет тут без света?", "");

            await Say(Voice, "Как ты посмел нарушить тайну веков?!", "");

            await Say(Skull, "Берегись! Стрелы! Это ловушка!", "");

            Fork();
        }
    }
}
