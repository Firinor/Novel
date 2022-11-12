using UnityEngine;

namespace FirGames.StoryPart2
{
    public class P2Scene1 : DialogNode
    {
        public override async void StartDialog()
        {
            base.StartDialog();

            CharacterInformator Vargus = storyInformator.Vargus;
            CharacterInformator Skull = storyInformator.Skull;

            Scene(storyInformator.Memorial);

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "Ќа поминках собрались все, и друзь€ и враги." +
                " Ѕудь внимателен, кажетс€, ¬аргус, давний соперник твоего отца, собираетс€ о себе за€вить.", "");

            await Say(Skull, "ќн мечтал о месте архимагистра долгие годы," +
                " строил козни твоему покойному отцу и теперь не оставит теб€ в покое.", "");

            Hide(Skull);

            Show(Vargus, PositionOnTheStage.Center, ViewDirection.Left);

            await Say(Vargus, "—мерть архимагистра ужасна€ трагеди€, он был дл€ нас примером воли, мудрости и милосерди€.", "");

            await Say(Vargus, "Ќадеюсь € смогу соответствовать высокой планке, установленной им дл€ главы нашего ордена.", "");

            Show(Skull, PositionOnTheStage.Left);

            await Say(Skull, "¬ыборов архимагистра еще не было. Ќе рано ли чистить лук к рыбе, когда она еще в озере.", "");

            await Say(Vargus, "≈сли ты о своем протеже, то у него недостаточно опыта.", "");

            await Say(Vargus, "–азве может стать архимагистором юный мечтатель," +
                " призывающий выкинуть казну ордена на безнадежную идею строительства портала?", "");

            Hide(Vargus);

            Show(Skull, PositionOnTheStage.Center);

            await Say(Skull, " ак лучше ему ответить?", "");

            Fork();
        }
    }
}