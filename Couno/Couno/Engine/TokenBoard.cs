using System;
using System.Collections.Generic;

namespace Couno.Engine
{
    public class TokenBoard : IResourceStreamlineElement
    {
        private readonly TokenBoardLayout _tokenBoardLayout;

        public TokenBoard(TokenBoardLayout tokenBoardLayout)
        {
            this._tokenBoardLayout = tokenBoardLayout;
            this.TokenSlots = new LinkedList<IAbilityToken>();
        }

        private LinkedList<IAbilityToken> TokenSlots { get; }

        internal void AddToken(IAbilityToken token)
        {
            this.TokenSlots.AddLast(token);
        }

        public IEnumerable<IAbilityToken> ExtractAbilities()
        {
            return this.TokenSlots;
        }

        public override string ToString()
        {
            return $"Board ({this.TokenSlots.Count})";
        }
    }
}