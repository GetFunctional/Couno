using System.Collections.Generic;

namespace Couno.Engine
{
    public interface ITarget
    {
        IList<Effect> Effects { get; }
        int Health { get; }

        void ReduceHealth(int amount);
    }
}