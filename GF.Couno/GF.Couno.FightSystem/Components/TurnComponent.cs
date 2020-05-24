using GF.Couno.FightSystem.Ecs;

namespace GF.Couno.FightSystem.Components
{
    public readonly struct TurnComponent : IComponent
    {
        public TurnComponent(int turn)
        {
            Turn = turn;
        }

        public int Turn { get; }
    }
}