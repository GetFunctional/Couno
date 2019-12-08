using System;
using Couno.Shared;

namespace Couno.Engine
{
    public sealed class AbilityToken : IAbilityToken
    {
        public AbilityToken(Ability ability, IAbilityToken ancestor, IAbilityToken descendant)
        {
            this.Ability = ability;
            this.Ancestor = ancestor;
            this.Descendant = descendant;
        }

        public IAbilityToken Ancestor { get; }
        public IAbilityToken Descendant { get; private set; }
        public void IntroduceDescendant(IAbilityToken descendant)
        {
            if (this.Descendant != null)
            {
                throw new InvalidOperationException("Already has a descendant");
            }

            this.Descendant = descendant;
        }

        public Ability Ability { get; }

        public override string ToString()
        {
            return this.Ability.ToString();
        }
    }
}