﻿using System;

namespace GF.Couno.CardGameProto
{
    public class Card : IEquatable<Card>
    {
        public Card(CardType cardType, int value)
        {
            this.CardType = cardType;
            this.Value = value;
        }

        public CardType CardType { get; }

        public int Value { get; }

        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.CardType == other.CardType && this.Value == other.Value;
        }

        public override string ToString()
        {
            return $"{Enum.GetName(typeof(CardType), this.CardType)}{this.Value.ToString()}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) this.CardType * 397) ^ this.Value;
            }
        }
    }
}