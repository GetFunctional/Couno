using System.Collections.Generic;

namespace Couno.Engine
{
    public class Character : TargetBase
    {
        public Character() : this(200, new List<Item>())
        {
        }

        public Character(int health, IList<Item> items) : base(health)
        {
            this.Items = items;
            this.Engine = new CounoEngine(new ResourceElementFactory());
        }

        public CounoEngine Engine { get; }

        private IList<Item> Items { get; }
    }
}