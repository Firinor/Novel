namespace FirGames.StoryPart3
{
    public class P3Scene16 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Voice = storyInformator.Voice;

            Scene(storyInformator.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Voice, "ћедвед€ можно научить двигатьс€ под музыку, но он никогда не сможет сочинить танец.", "");

            await Say(Skull, "ќтвлекись от танцующих медведей и взгл€ни на дерево." +
                " “олько оно не мен€етс€ в этом хранилище иллюзий.", "");

            Fork();
        }
    }
}
