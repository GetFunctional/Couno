namespace Couno.Engine
{
    public interface ICounoFightEnvironment
    {
        Character Player { get; }

        Character Enemy { get; }

        TargetSelectionRequirement GetTargetSelectionRequirementForAction(Character character, IAbilityToken ability);
        ITarget AutoSelectTargetForAction(Character character, IAbilityToken ability);
        object ResolveAbility(Character character, IAbilityToken ability, ITarget target);
    }
}