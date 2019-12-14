using System.Collections.Generic;
using System.Linq;

namespace Couno.Engine
{
    public class ResourceGenerator : IResourceStreamlineElement
    {
        public ResourceType ResourceType { get; }
        public int Amount { get; }

        public ResourceGenerator(ResourceType resourceType, int amount)
        {
            this.ResourceType = resourceType;
            this.Amount = amount;
        }

        public IEnumerable<IAbilityToken> ExtractAbilities()
        {
            return Enumerable.Empty<IAbilityToken>();
        }

        public override string ToString()
        {
            return $"Generator ({this.ResourceType} ({this.Amount})";
        }
    }
}