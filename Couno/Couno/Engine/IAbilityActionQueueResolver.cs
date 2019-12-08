namespace Couno.Engine
{
    internal interface IAbilityActionQueueResolver
    {
        ResolveResult Resolve(IAbilityToken abilityAction, ICounoFightEnvironment fight, ITarget target);

        TargetSelectionRequirement GetTargetSelectionRequirement(IAbilityToken abilityAction,
            ICounoFightEnvironment fight);

        ITarget AutoSelectTarget(IAbilityToken abilityAction, ICounoFightEnvironment fight);
    }
}