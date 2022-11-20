namespace FirGames.StoryPart3
{
    public class P3Scene5_2_1_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.BeginOfElvenForest);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Сейчас эльфы ведут себя мирно и считаются пацифистами," +
                " но большое заблуждение думать, что они были такими всегда." +
                " Огромное количество воинов погибло в борьбе кланов за власть.", "");

            await Say(Skull, "По моему мнению, эльфы сейчас ведут себя тихо не по доброте душевной," +
                " а потому что воевать некому. Вполне возможно, Тиир из рода владык и сейчас ищет" +
                " способы объединить свой народ.", "");

            Fork();
        }
    }
}
