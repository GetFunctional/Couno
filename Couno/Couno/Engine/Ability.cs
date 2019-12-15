using System.Collections.Generic;

namespace Couno.Engine
{
    public sealed class Ability
    {
        public Ability(string name, AbilityType abilityType, int amount) : this(name, abilityType, ResourceType.Red, amount)
        {
        }

        public Ability(string name, AbilityType abilityType, ResourceType resourceType, int amount) : this(name, abilityType, resourceType, amount, 0, 0, 0)
        {
        }

        public Ability(string name, AbilityType abilityType, ResourceType resourceType, int amount, int redRequirement, int blueRequirement, int greenRequirement)
        {
            this.Name = name;
            this.AbilityType = abilityType;
            this.Amount = amount;
            this.ResourceType = resourceType;
            this.ResourceRequirements = CreateResourceRequirements(redRequirement, blueRequirement, greenRequirement);
        }

        private Dictionary<ResourceType, int> CreateResourceRequirements(int redRequirement, int blueRequirement, int greenRequirement)
        {
            return new Dictionary<ResourceType, int>()
            {
                { ResourceType.Red, redRequirement },
                {ResourceType.Blue, blueRequirement },
                {ResourceType.Green, greenRequirement}
            };
        }

        public Dictionary<ResourceType, int> ResourceRequirements { get; }

        public int Amount { get; }

        public string Name { get; }

        public AbilityType AbilityType { get; }

        public ResourceType ResourceType { get; }

        public override string ToString()
        {
            return $"{AbilityType} ({this.Amount})";
        }
    }
}