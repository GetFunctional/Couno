using System;

namespace GF.Couno.FightSystem.Events
{
    public abstract class FightEventBase : IFightEvent
    {
        protected FightEventBase(int eventId, DateTime executed, int turn)
        {
            EventId = eventId;
            Executed = executed;
            Turn = turn;
        }

        public DateTime Executed { get; }

        public int Turn { get; }

        public int EventId { get; }
    }
}