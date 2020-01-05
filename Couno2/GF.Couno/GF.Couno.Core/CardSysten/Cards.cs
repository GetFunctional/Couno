using System;
using System.Collections.Generic;
using System.Linq;
using GF.Couno.Core.Extensions;

namespace GF.Couno.Core.CardSysten
{
    public sealed class Cards
    {
        private Stack<Card> _stackedCards;

        public Cards() : this(Enumerable.Empty<Card>())
        {
        }


        public Cards(IEnumerable<Card> cards)
        {
            this._stackedCards = new Stack<Card>(cards);
        }

        public IReadOnlyCollection<Card> StackedCards
        {
            get { return this._stackedCards; }
        }

        public Card TopCard
        {
            get { return this._stackedCards.Peek(); }
        }

        public void PutOnTop(Card card)
        {
            this._stackedCards.Push(card);
        }

        public void ShuffleInside(Card card)
        {
            this.PutOnTop(card);
            this.Shuffle();
        }

        public Card PeekRandom()
        {
            return this.StackedCards.PickRandom(1).SingleOrDefault();
        }

        public Card TakeCard(Card card)
        {
            var cardStack = this._stackedCards.ToList();
            if (!cardStack.Remove(card))
            {
                throw new InvalidOperationException("Card was not on the stack.");
            }

            this._stackedCards = new Stack<Card>(cardStack);
            return card;
        }

        public Card TakeTopCard()
        {
            return this._stackedCards.Pop();
        }

        public IReadOnlyCollection<Card> Shuffle()
        {
            this._stackedCards = new Stack<Card>(this.StackedCards.Shuffle());
            return this._stackedCards;
        }
    }
}