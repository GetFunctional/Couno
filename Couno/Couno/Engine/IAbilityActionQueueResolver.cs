using System.Collections.Generic;

namespace Couno.Engine
{
    internal interface IAbilityActionQueueResolver
    {
        ResolveResult Resolve(Character character, IAbilityToken ability, IList<ITarget> enemiesOfCharacter);

        TargetSelectionRequirement GetTargetSelectionRequirement(Character character, IAbilityToken ability);

        ITarget AutoSelectTarget(Character character, IAbilityToken ability, IList<ITarget> enemiesOfCharacter);
    }
}