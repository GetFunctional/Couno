using System.Collections;
using System.Collections.Generic;

namespace Couno.Engine
{
    internal interface IAbilityActionQueueResolver
    {
        ResolveResult Resolve(IAbilityToken abilityAction, ITarget executor, ITarget target);

        TargetSelectionRequirement GetTargetSelectionRequirement(IAbilityToken abilityAction,
            ICounoFightEnvironment fight);

        ITarget AutoSelectTarget(IAbilityToken abilityAction, ITarget executor, IList<ITarget> enemies);

        ITarget AutoSelectTarget(IAbilityToken abilityAction, ITarget executor, ITarget enemy);

    }
}