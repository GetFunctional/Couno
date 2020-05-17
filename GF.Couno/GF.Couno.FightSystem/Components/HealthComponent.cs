using GF.Couno.FightSystem.Ecs;

namespace GF.Couno.FightSystem.Components
{
    public readonly struct HealthComponent : IComponent
    {
        public HealthComponent(int health)
        {
            Health = health;
        }

        public int Health { get; }
    }
}