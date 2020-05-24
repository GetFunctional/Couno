using System;
using GF.Couno.FightSystem.Entities;

namespace GF.Couno.FightSystem.Events
{
    public class DamageDealt : FightEventBase
    {
        public DamageDealt(int eventId, DateTime executed, int turn, int damage, FighterId targetId, FighterId sourceId) : base(eventId, executed, turn)
        {
            Damage = damage;
            TargetId = targetId;
            SourceId = sourceId;
        }

        public int Damage { get; set; }

        public FighterId TargetId { get; set; }

        public FighterId SourceId { get; set; }
    }
}