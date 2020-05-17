using GF.Couno.FightSystem.Components;
using GF.Couno.FightSystem.Ecs;

namespace GF.Couno.FightSystem.Systems
{
    internal class DamageSystem
    {
        internal void ApplyDamage(int damage, IEntity entity)
        {
            var shieldComponent = entity.Components.GetComponent<ShieldComponent>();

            if (shieldComponent.Shield > 0)
            {
                if (shieldComponent.Shield > damage)
                {
                    entity.Components.ChangeComponent<ShieldComponent>(existing => new ShieldComponent(existing.Shield - damage));
                    return;
                }

                entity.Components.ChangeComponent<ShieldComponent>(existing =>
                {
                    damage = damage - existing.Shield;
                    return new ShieldComponent(0);
                });
            }

            entity.Components.ChangeComponent<HealthComponent>(cmp =>
                new HealthComponent(cmp.Health - damage));
        }
    }
}