namespace FirGames.StoryPart3
{
    public class P3Scene17 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.AtElvenPalace);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Три: юноша, взрослый мужчина и старик. " +
                "Отсюда три манеры поведения: игра, рассуждения и ворчание.", "");

            await Say(Skull, "Я, кажется, понял, что происходит. " +
                "Камни, из которых построена пирамида, поглощают магическую энергию.", "");

            await Say(Skull, "Чем больше Тиир и компания пытались разрушить барьер, тем сильнее он становился." +
                " Накопившаяся за многие года магия создала хаос, в котором мы оказались.", "");

            await Say(Skull, "Нужно деактивировать хранилище, тогда энергия рассеется. " +
                "Взгляни, под деревом плита с символами. Возможно, это ключ.", "");

            Fork();
        }
    }
}
