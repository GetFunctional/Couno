using System.Collections.Generic;

namespace Couno.Engine
{
    public abstract class TargetBase : ITarget
    {
        protected TargetBase(int health) : this(health, 0, new List<Effect>())
        {
        }

        protected TargetBase(int health, int block, IList<Effect> effects)
        {
            this.Health = health;
            this.Block = block;
            this.Effects = effects;
        }

        public int Health { get; private set; }
        public int Block { get; private set; }
        public bool IsAlive
        {
            get { return this.Health > 0; }
        }

        public IList<Effect> Effects { get; }

        public int ReduceHealth(int amount)
        {
            if (this.Health > amount)
            {
                this.Health -= amount;
            }
            else
            {
                this.Health = 0;
            }

            return this.Health;
        }

        public int AddBlock(int amount)
        {
            this.Block += amount;
            return this.Block;
        }

        public int ReduceBlock(int amount)
        {
            if (this.Block > amount)
            {
                this.Block -= amount;
            }
            else
            {
                this.Block = 0;
            }

            return this.Block;
        }
    }
}