namespace FirGames.StoryPart4
{
    public class P4Scene21 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Bathyard = Characters.Bathyard;
            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.OrcEncampment);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, "Вот и стойбище. Пора снять защиту. " +
                "Обрати внимание на того молодого орка. Судя по украшением он сын вождя.", "");

            Show(Skull, PositionOnTheStage.Left);
            Show(Bathyard, PositionOnTheStage.Right);

            await Say(Bathyard, "Кто вы и зачем пришли?", "");

            await Say(Skull, "Мы принесли дары великому вождю Вацеле от герцога людей Аргуза.", "");

            await Say(Bathyard, "Очередные пустословы! Учтите, таким мы даем право самим выбрать" +
                " себе смерть, если сильно докучают.", "");
            await Say(Bathyard, "Что предпочитаете: отсечение головы, копыта степных вепрей, " +
                "вспарывание живота, удушение тетивой лука?", "");

            await Say(Skull, "Можно свой вариант, более страшный и неотвратимый?", "");

            await Say(Bathyard, "Что может быть неизбежнее копыт вепрей?", "");

            await Say(Skull, "Старость. Великий предок Вацелы Кармильхан в одиночку справился" +
                " со стадом вепрей, но даже ему не удалось одолеть старость.", "");

            await Say(Bathyard, "А вы забавные! Идем, отведу к отцу.", "");

            Fork();
        }
    }
}
