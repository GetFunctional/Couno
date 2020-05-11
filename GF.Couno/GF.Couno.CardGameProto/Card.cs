using System;

namespace GF.Couno.CardGameProto
{
    public class Card : IEquatable<Card>
    {
        public Card(CardType cardType, int value)
        {
            CardType = cardType;
            Value = value;
        }

        public CardType CardType { get; }

        public int Value { get; }

        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CardType == other.CardType && Value == other.Value;
        }

        public override string ToString()
        {
            return $"{Enum.GetName(typeof(CardType), CardType)}{Value.ToString()}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) CardType * 397) ^ Value;
            }
        }
    }
}