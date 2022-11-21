namespace FirGames.StoryPart4
{
    public class P4Scene8 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Mercenary = Characters.Mercenary;

            Show(Mercenary, PositionOnTheStage.Right, ViewDirection.Right);
            Show(Skull, PositionOnTheStage.Left);

            Scene(Backgrounds.Tents);

            await Say(Skull, "Южнее расположился небольшой отряд орков.", "");
            await Say(Skull, "Если они нападут, наемников королевы станет меньше и мы сможем узнать" +
                " как обстоят дела в Карпатии. Давай привлечем их внимание.", "");

            Fork();
        }
    }
}
