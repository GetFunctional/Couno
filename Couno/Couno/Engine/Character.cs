using System.Collections.Generic;
using System.ComponentModel;

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
        }

        private IList<Item> Items { get; }
    }
}