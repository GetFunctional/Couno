using System.Collections.Generic;

namespace Couno.Engine
{
    public interface IResourceStreamlineElement
    {
        IEnumerable<IAbilityToken> ExtractAbilities();
    }
}