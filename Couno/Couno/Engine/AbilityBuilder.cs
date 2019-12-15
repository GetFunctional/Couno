namespace Couno.Engine
{
    public sealed class AbilityBuilder
    {
        public IAbilityToken CreateDamageAbility()
        {
            return this.CreateDamageAbility(6);
        }

        public IAbilityToken CreateDamageAbility(int baseDamage)
        {
            var ability = new Ability("Attack", AbilityType.Attack, baseDamage);
            var abilityToken = new AbilityToken(ability);
            return abilityToken;
        }

        public IAbilityToken CreateBlockAbility(int baseBlock)
        {
            var ability = new Ability("Block", AbilityType.Block, baseBlock);
            var abilityToken = new AbilityToken(ability);
            return abilityToken;
        }
    }
}