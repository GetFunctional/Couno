using GF.Couno.Core.CardSysten;

namespace GF.Couno.Core.FightSystem.Shared
{
    public sealed class ParticipantCards
    {
        public ParticipantCards() : this(new Cards())
        {
        }

        public ParticipantCards(Cards handCards) : this(handCards, new Cards())
        {
        }

        public ParticipantCards(Cards handCards, Cards discardedCards) : this(handCards, discardedCards,
            new Cards())
        {
        }

        public ParticipantCards(Cards handCards, Cards discardedCards, Cards playedCards)
        {
            this.HandCards = handCards;
            this.DiscardedCards = discardedCards;
            this.PlayedCards = playedCards;
        }
        
        public Cards HandCards { get; }
        public Cards DiscardedCards { get; }
        public Cards PlayedCards { get; }
    }
}