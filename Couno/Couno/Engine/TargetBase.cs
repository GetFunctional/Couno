using System.Collections.Generic;

namespace Couno.Engine
{
    public abstract class TargetBase : ITarget
    {
        public int Health { get; protected set; }

        public bool IsAlive
        {
            get { return this.Health > 0; }
        }

        public IList<Effect> Effects { get; }

        public void ReduceHealth(int amount)
        {
            this.Health -= amount;
        }
    }
}