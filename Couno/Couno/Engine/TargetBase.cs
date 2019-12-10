using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Couno.Engine
{
    public abstract class TargetBase : ITarget, INotifyPropertyChanged
    {
        private int _health;
        private int _block;

        protected TargetBase(int health) : this(health, 0, new List<Effect>())
        {
        }

        protected TargetBase(int health, int block, IList<Effect> effects)
        {
            this.Health = health;
            this.Block = block;
            this.Effects = effects;
        }

        public int Health
        {
            get { return this._health; }
            private set
            {
                this._health = value;
                this.RaisePropertyChanged();
            }
        }

        public int Block
        {
            get { return this._block; }
            private set
            {
                this._block = value;
                this.RaisePropertyChanged();
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}