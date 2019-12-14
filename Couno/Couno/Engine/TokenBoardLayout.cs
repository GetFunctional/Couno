using System;
using System.Collections.Generic;

namespace Couno.Engine
{
    public class TokenBoardLayout
    {
        public TokenBoardLayout(int amountOfSlots)
        {
            this.AmountOfSlots = amountOfSlots;
            this.TokenSlots = new Dictionary<int, Ability>();
        }

        public int AmountOfSlots { get; }
        private Dictionary<int, Ability> TokenSlots { get; }

    }
}