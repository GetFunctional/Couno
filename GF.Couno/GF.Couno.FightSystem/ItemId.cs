using System;

namespace GF.Couno.FightSystem
{
    public sealed class ItemId : IEquatable<ItemId>
    {
        public ItemId() : this(Guid.NewGuid())
        {
        }

        public ItemId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public bool Equals(ItemId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is ItemId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}