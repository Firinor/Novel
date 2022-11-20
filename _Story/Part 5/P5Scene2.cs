namespace FirGames.StoryPart3
{
    public class P3Scene2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Vargus = Characters.Vargus;

            Scene(Backgrounds.FirePlace);

            Show(Skull, PositionOnTheStage.Left);
            Show(Vargus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Vargus, "Собираете лавры?", "");

            await Say(Skull, "Мы тоже рады тебя видеть.", "");

            await Say(Vargus, "Вот, ознакомьтесь с приказом королевы.", "");

            await Say(Vargus, "До выборов нового архимагистра доступ к порталу будет только у меня и у моего помощника." +
                " Строительство новых порталов должно согласовываться лично с королевой.", "");

            await Say(Skull, "Даже не знаю, что тут сказать.", "");

            Fork();
        }
    }
}
