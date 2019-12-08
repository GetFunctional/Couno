using Couno.Engine;

namespace Couno
{
    internal class CounoTestFight : ICounoFightEnvironment
    {
        public CounoTestFight(Player player, Enemy enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
        }

        public Player Player { get; }
        public Enemy Enemy { get; }
    }
}