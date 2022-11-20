namespace FirGames.StoryPart4
{
    public class P4Scene1_3 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = Characters.Skull;
            CharacterInformator Vargus = Characters.Vargus;

            Scene(Backgrounds.Lab);

            Show(Skull, PositionOnTheStage.Center);
            Show(Vargus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "Достаточно! С этого дня, Варгус, ты больше не являешься членом ордена Познающих.", "");
            await Say(Skull, "Если попытаешься использовать порталы без разрешения, будешь арестован.", "");

            await Say(Vargus, "Я буду жаловаться королеве.", "");

            await Say(Skull, "Просители годами ждут рассмотрения своих дел. Даже не знаю," +
                " сумеешь ли ты выстоять в очереди жалобщиков в твои-то года.", "");

            Fork();
        }
    }
}
