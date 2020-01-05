using System.Collections.Generic;
using GF.Couno.Core.Extensions;

namespace GF.Couno.Core.CardSysten
{
    public class Card
    {
        public Card(IList<CardEffect> cardEffects, CardCost cardCost)
        {
            this.CardEffects = cardEffects;
            this.CardCost = cardCost;
        }

        public IList<CardEffect> CardEffects { get; }

        public CardCost CardCost { get; }

    }
}