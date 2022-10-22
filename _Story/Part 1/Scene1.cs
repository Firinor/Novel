using UnityEngine;

namespace FirGames.StoryPart1
{
    public class Scene1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Archmagister = storyInformator.Archmagister;

            Sprite Lab = storyInformator.Lab;

            Scene(Lab);

            Show(Archmagister, PositionOnTheStage.Right);

            await Say(Archmagister, "ƒит€ мое, настал день твоего экзамена." +
                " ¬ечером ты уже будешь признанным магистром и мы сможем отпраздновать.", "");

            await Say(Archmagister, "ѕринимать экзамен будет наимудрейший беспристрастный основатель нашего ордена," +
                " лучше других знающий к каким последстви€м приводит риск в нашем деле.", "");

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "ѕопрошу без намеков! “о заклинание должно было сделать мен€ бессмертным.", "");

            await Say(Archmagister, "вы и стали бессмертным.", "");

            await Say(Skull, "вот поживешь с мое.", "");

            await Say(Archmagister, "сейчас € должен открыть портал дл€ прохода торгового каравана в столицу. ќставл€ю вас." +
                " ƒит€ мое, помни, что € горжусь тобой и все уже готово дл€ праздновани€.", "");

            Fork();
        }
    }
}