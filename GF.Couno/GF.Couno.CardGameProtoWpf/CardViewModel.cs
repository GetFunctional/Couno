using System;
using GF.Couno.CardGameProto;

namespace GF.Couno.CardGameProtoWpf
{
    public class CardViewModel
    {
        public CardViewModel(Card card)
        {
            Card = card;
            this.Name = card.ToString();
        }

        public Card Card { get; }

        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}