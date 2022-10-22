using UnityEngine;

namespace FirGames.StoryPart2
{
    public class Scene1_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Varus = storyInformator.Varus;
            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Memorial);

            Show(Skull, PositionOnTheStage.Left);
            Show(Varus, PositionOnTheStage.Center);

            await Say(Skull, "Архимагистр должен соблюдать закон орден, а в нем четко прописано," +
                " что выборы главы ордена проходят через 15 дней после смерти предыдущего, не раньше.", "");

            await Say(Varus, "Я знаю законы! Через 15 дней," +
                " если молодой наглец не научится уважать старших, мы поговорим совсем по-другому.", "");

            Fork();
        }
    }
}