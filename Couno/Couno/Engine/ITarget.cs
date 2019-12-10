using System.Collections.Generic;

namespace Couno.Engine
{
    public interface ITarget
    {
        IList<Effect> Effects { get; }
        int Health { get; }
        int Block { get; }

        int ReduceHealth(int amount);
        int AddBlock(int amount);

        /// <summary>
        /// Reduces the amount of Block.
        /// </summary>
        /// <param name="amount">Reducing Block by this value.</param>
        /// <returns>Remaining Blockvalue. Stops reduction when reaching 0.</returns>
        int ReduceBlock(int amount);
    }
}