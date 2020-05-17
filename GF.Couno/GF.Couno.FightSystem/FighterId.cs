using System;

namespace GF.Couno.FightSystem
{
    public sealed class FighterId : IEquatable<FighterId>
    {
        public FighterId() : this(Guid.NewGuid())
        {
        }

        public FighterId(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }

        public bool Equals(FighterId other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || obj is FighterId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}