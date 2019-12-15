using System.Collections.Generic;
using Couno.Engine;

namespace Couno
{
    internal class TokenFactory
    {
        private readonly AbilityBuilder _abilityBuilder = new AbilityBuilder();

        public IList<IAbilityToken> GetAllAvailableTokens()
        {
            return new List<IAbilityToken>()
            {
                this._abilityBuilder.CreateDamageAbility(6),
                this._abilityBuilder.CreateBlockAbility(6)
            };
        }


    }
}