namespace FirGames.StoryPart4
{
    public class P4Scene10 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Mercenary = Characters.Mercenary;

            Show(Skull, PositionOnTheStage.Center);
            Show(Mercenary, PositionOnTheStage.Right);

            Scene(Backgrounds.Tents);

            await Say(Skull, "Выбирай: будешь отвечать по хорошему или архимагистр споет тебе гимн Арфараха?", "");

            await Say(Mercenary, "Споет?! Нет, только не это. Я все скажу.", "");

            await Say(Skull, "Королева приказала убить архимагистра?", "");

            await Say(Mercenary, "Да и обещала хорошую награду. Все должно было выглядеть как несчастный случай.", "");

            await Say(Skull, "Что будем с ними делать?", "");

            Fork();
        }
    }
}
