namespace FirGames.StoryPart4
{
    public class P4Scene23 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Bathyard = Characters.Bathyard;

            Scene(Backgrounds.OrcEncampment);

            Show(Bathyard, PositionOnTheStage.Right);
            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Какой кошмар, заставлять тринадцатилетних подростков " +
                "засовывать руки в наполненные кусачими муравьями варежки!", "");
            await Say(Skull, "А еще говорят, что у магов ордена познающих строгие экзамены.", "");

            await Say(Bathyard, "Ты мало ешь. На пиру нужно попробовать все блюда,", "");
            await Say(Bathyard, "но если пища орков слишком груба для твоего желудка, можем предложить " +
                "что-нибудь более привычное, например, грудное молоко.", "");

            await Say(Skull, "Отказ его оскорбит. Вон те червяки в соусе выглядят неплохо." +
                " Представь, что это экзотический салат.", "");

            Fork();
        }
    }
}
