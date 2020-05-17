using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using GF.Couno.FightSystem.Components;
using GF.Couno.FightSystem.Effects;
using GF.Couno.FightSystem.Events;
using GF.Couno.FightSystem.Systems;

namespace GF.Couno.FightSystem
{
    internal class Fight
    {
        private ShieldSystem ShieldSystem = new ShieldSystem();
        private DamageSystem DamageSystem = new DamageSystem();

        public Fight(Queue<Fighter> fightersInTurnOrder) : this(fightersInTurnOrder, new Queue<IFightEvent>())
        {
        }

        public Fight(Queue<Fighter> fightersInTurnOrder, Queue<IFightEvent> events)
        {
            this.FightParticipants = fightersInTurnOrder.ToDictionary(key => key.FighterId, val => val);
            this.FightersInTurnOrder = fightersInTurnOrder;
            this.ReplayEvents(events);
        }

        private Dictionary<FighterId, Fighter> FightParticipants { get; set; }

        private void ReplayEvents(Queue<IFightEvent> events)
        {
            foreach (var fightEvent in events)
            {
                this.ApplyEvent((dynamic)fightEvent);
                Events.Enqueue(fightEvent);
            }
        }

        private void ApplyEvent(DamageDealt damageDealt)
        {
            var target = this.FightParticipants[damageDealt.TargetId];
            DamageSystem.ApplyDamage(damageDealt.Damage, target);
        }

        private void ApplyEvent(ShieldGenerated shieldGenerated)
        {
            var target = this.FightParticipants[shieldGenerated.TargetId];
            ShieldSystem.ApplyShield(shieldGenerated.ShieldAmount, target);
        }


        public Queue<IFightEvent> Events { get; } = new Queue<IFightEvent>();
        public Queue<Fighter> FightersInTurnOrder { get; }
    }
}
