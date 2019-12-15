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

        public IAbilityToken CreateRedResourceGeneratorAbility(int resourceGeneration)
        {
            var ability = new Ability("ResourceGenerator", AbilityType.AddResource, ResourceType.Red, resourceGeneration);
            var abilityToken = new AbilityToken(ability);
            return abilityToken;
        }

        public IAbilityToken CreateBlueResourceGeneratorAbility(int resourceGeneration)
        {
            var ability = new Ability("ResourceGenerator", AbilityType.AddResource, ResourceType.Blue, resourceGeneration);
            var abilityToken = new AbilityToken(ability);
            return abilityToken;
        }

        public IAbilityToken CreateGreenResourceGeneratorAbility( int resourceGeneration)
        {
            var ability = new Ability("ResourceGenerator", AbilityType.AddResource, ResourceType.Green, resourceGeneration);
            var abilityToken = new AbilityToken(ability);
            return abilityToken;
        }

    }
}