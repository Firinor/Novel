namespace FirGames.StoryPart3
{
    public class P3Scene5_1_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Yanus = storyInformator.Yanus;

            Scene(storyInformator.PrisonersСell);

            Show(Skull, PositionOnTheStage.Left);
            Show(Yanus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "Живые или мертвые, но они все остались в аквариуме. Хотя как рыба может утонуть?", "");

            await Say(Yanus, "Может, если плотно накрыть крышкой аквариум и не менять воду.", "");

            await Say(Skull, "Смотрю, ты хорошо устроился.", "");

            await Say(Yanus, "Я объяснял людям, что нам дана возможность выбора, но не дано возможности избежать выбора.", "");

            await Say(Skull, "Начальнику охраны вряд ли понравится, если его люди начнут сами выбирать себе обязанности.", "");

            await Say(Yanus, "Трудности делают нас сильнее.", "");

            await Say(Skull, "А эту философскую мысль вряд ли оценят семьи охранников.", "");

            Fork();
        }
    }
}
