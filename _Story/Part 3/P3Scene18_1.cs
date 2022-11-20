namespace FirGames.StoryPart3
{
    public class P3Scene18_1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Tiir = Characters.Tiir;

            Scene(Backgrounds.AtElvenPalace2);

            Show(Skull, PositionOnTheStage.Left);
            Show(Tiir, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Tiir, "Я ожидал полную библиотеку книг или светящийся шар, но все оказалось сложнее." +
                " Объединив наши силы, мы сможем понять, как пользоваться пирамидой.", "");

            await Say(Tiir, "Уверен, строительство порталов покажется детской игрой по сравнению с тем, что мы узнаем.", "");

            await Say(Skull, "И обязательно задокументируем.", "");

            Fork();
        }
    }
}
