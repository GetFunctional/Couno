using System;
using System.Collections.Generic;
using Couno.Shared;

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

        public void ReplaceAbilities(IEnumerable<IAbilityToken> currentConfiguration)
        {
            this.TokenSlots.Clear();
            currentConfiguration.ForEach(x => this.TokenSlots.AddLast(x));
        }

        public override string ToString()
        {
            return $"Board ({this.TokenSlots.Count})";
        }
    }
}