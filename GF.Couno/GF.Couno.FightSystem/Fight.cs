using System.Collections.Generic;
using System.Linq;
using GF.Couno.FightSystem.Entities;
using GF.Couno.FightSystem.Events;
using GF.Couno.FightSystem.Systems;

namespace GF.Couno.FightSystem
{
    internal class Fight
    {
        private readonly DamageSystem DamageSystem = new DamageSystem();
        private readonly ShieldSystem ShieldSystem = new ShieldSystem();

        public Fight(Queue<Fighter> fightersInTurnOrder) : this(fightersInTurnOrder, new Queue<IFightEvent>())
        {
        }

        public Fight(Queue<Fighter> fightersInTurnOrder, Queue<IFightEvent> events)
        {
            FightParticipants = fightersInTurnOrder.ToDictionary(key => key.FighterId, val => val);
            FightersInTurnOrder = fightersInTurnOrder;
            ReplayEvents(events);
        }

        private Dictionary<FighterId, Fighter> FightParticipants { get; }


        public Queue<IFightEvent> Events { get; } = new Queue<IFightEvent>();
        public Queue<Fighter> FightersInTurnOrder { get; }

        private void ReplayEvents(Queue<IFightEvent> events)
        {
            foreach (var fightEvent in events)
            {
                this.ApplyEvent((dynamic) fightEvent);
                Events.Enqueue(fightEvent);
            }
        }

        private void ApplyEvent(DamageDealt damageDealt)
        {
            var target = FightParticipants[damageDealt.TargetId];
            DamageSystem.ApplyDamage(damageDealt.Damage, target);
        }

        private void ApplyEvent(ShieldGenerated shieldGenerated)
        {
            var target = FightParticipants[shieldGenerated.TargetId];
            ShieldSystem.ApplyShield(shieldGenerated.ShieldAmount, target);
        }
    }
}