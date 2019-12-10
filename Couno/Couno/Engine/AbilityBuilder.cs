namespace Couno.Engine
{
    public sealed class AbilityBuilder
    {
        public IAbilityToken CreateDamageAbility()
        {
            return this.CreateDamageAbility(6, null, null);
        }

        public IAbilityToken CreateDamageAbility(int baseDamage)
        {
            return this.CreateDamageAbility(baseDamage, null, null);
        }

        public IAbilityToken CreateDamageAbility(int baseDamage, IAbilityToken ancestor, IAbilityToken descendant)
        {
            var ability = new Ability("Attack", AbilityType.Attack, baseDamage);
            var abilityToken = new AbilityToken(ability, ancestor, descendant);
            
            if (ancestor is AbilityToken at)
            {
                at.IntroduceDescendant(abilityToken);
            }

            return abilityToken;
        }

        public IAbilityToken CreateBlockAbility(int baseBlock, IAbilityToken ancestor, IAbilityToken descendant)
        {
            var ability = new Ability("Block", AbilityType.Block, baseBlock);
            var abilityToken = new AbilityToken(ability, ancestor, descendant);
            
            if (ancestor is AbilityToken at)
            {
                at.IntroduceDescendant(abilityToken);
            }

            return abilityToken;
        }
    }
}