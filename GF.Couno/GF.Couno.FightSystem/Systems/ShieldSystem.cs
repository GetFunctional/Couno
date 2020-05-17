using GF.Couno.FightSystem.Components;
using GF.Couno.FightSystem.Ecs;

namespace GF.Couno.FightSystem.Systems
{
    internal class ShieldSystem
    {
        internal void ApplyShield(int shield, IEntity entity)
        {
            entity.Components.ChangeComponent<ShieldComponent>(shld =>
                new ShieldComponent(shld.Shield + shield));
        }
    }
}