using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene1_2 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Vargus = Characters.Vargus;
            CharacterInformator Skull = Characters.Skull;

            Scene(Backgrounds.Memorial);

            Show(Skull, PositionOnTheStage.Left);
            Show(Vargus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Skull, "Архимагистр должен соблюдать закон орден, а в нем четко прописано," +
                " что выборы главы ордена проходят через 15 дней после смерти предыдущего, не раньше.", "");

            await Say(Vargus, "Я знаю законы! Через 15 дней," +
                " если молодой наглец не научится уважать старших, мы поговорим совсем по-другому.", "");

            Fork();
        }
    }
}