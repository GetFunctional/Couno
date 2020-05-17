using GF.Couno.FightSystem.Ecs;

namespace GF.Couno.FightSystem.Components
{
    public readonly struct ShieldComponent : IComponent
    {
        public ShieldComponent(int shield)
        {
            Shield = shield;
        }

        public int Shield { get; }
    }
}