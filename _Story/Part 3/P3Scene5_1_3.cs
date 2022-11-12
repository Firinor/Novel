namespace FirGames.StoryPart3
{
    public class P3Scene5_1_3 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Skull = storyInformator.Skull;
            CharacterInformator Yanus = storyInformator.Yanus;

            Scene(storyInformator.PrisonersСell);

            Show(Skull, PositionOnTheStage.Left);
            Show(Yanus, PositionOnTheStage.Right, ViewDirection.Left);

            await Say(Skull, "Мы пришли спросить, знаешь ли ты эльфа-алхимика по имени Тиир." +
                " Он заходил к нам, пригласил в свой лес обсудить выгодное предложение.", "");

            await Say(Yanus, "Знаю. Тиир фанатик, одержим идеей возродить былое величие эльфийского народа." +
                " Про таких говорят, что нет надежнее друга, нет страшнее врага.", "");
            await Say(Yanus, "Поссорившийся с Тииром рискует стать последним в своем роду," +
                " но для друзей алхимик пойдет на многое, не считаясь с законом и моралью.", "");

            await Say(Skull, "Так нам идти или нет?", "");

            await Say(Yanus, "Идите. Если Тиир захочет вас убить, он это сделает, и никакие стены не спасут.", "");

            await Say(Skull, "Ты всегда умел вдохновить. А что случилось с губернатором? Он не оценил твои мудрые речи?", "");

            await Say(Yanus, "Губернатор сам пришел ко мне, рассказал о смерти своей единственной дочери, добавил," +
                " что готов на все, лишь бы с ней воссоединиться. Я выполнил его желание.", "");

            await Say(Skull, "А тебе не приходило в голову, что он просил воскресить дочь, а не умертвить его?", "");

            await Say(Yanus, "Жизнь и смерть две стороны одной медали.", "");

            await Say(Skull, "Эту речь я знаю наизусть во всех ее вариациях. Нам пора, Тиир ждет.", "");

            Fork();
        }
    }
}
