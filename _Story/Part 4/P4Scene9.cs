namespace FirGames.StoryPart4
{
    public class P4Scene9 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            await ShowImage(Backgrounds.War);

            CharacterInformator Skull = Characters.Skull;

            Show(Skull, PositionOnTheStage.Center);

            Scene(Backgrounds.Tents);

            await Say(Skull, "Чудесно, из отряда наемников королевы в живых осталось пятеро," +
                " из них трое ранены. Главарь орков взят в плен.", "");
            await Say(Skull, "Теперь настало время поговорить с одним из наших сопровождающих по душам.", "");

            Fork();
        }
    }
}
