using System;

namespace GF.Couno.FightSystem.Events
{
    public interface IFightEvent
    {
        DateTime Executed { get; }

        int Turn { get; }

        int EventId { get; }
    }
}