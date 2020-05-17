using System;

namespace GF.Couno.FightSystem
{
    public sealed class FightId : IEquatable<FightId>
    {
        public FightId() : this(Guid.NewGuid())
        {
        }

        public FightId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public bool Equals(FightId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is FightId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}