using System;
using GF.Couno.FightSystem.Entities;

namespace GF.Couno.FightSystem.Events
{
    internal class ShieldGenerated : FightEventBase
    {
        public ShieldGenerated(int eventId, DateTime executed, int turn, int shieldAmount, FighterId targetId) : base(eventId, executed, turn)
        {
            ShieldAmount = shieldAmount;
            TargetId = targetId;
        }

        public int ShieldAmount { get; }

        public FighterId TargetId { get; }
    }
}