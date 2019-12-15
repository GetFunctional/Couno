using System;

namespace Couno.Engine
{
    public interface ICounoFightEnvironment
    {
        event EventHandler<ActiveCharacterChangedEventArgs> ActiveCharacterChanged;

        Character Player { get; }

        Character Enemy { get; }

        TargetSelectionRequirement GetTargetSelectionRequirementForAction(Character character, IAbilityToken ability);
        ITarget AutoSelectTargetForAction(Character character, IAbilityToken ability);
        object ResolveAbility(Character character, IAbilityToken ability, ITarget target);
        void StartTurn(Character character);
        void FinishTurn(Character character);
        bool IsItMyTurn(Character character);
        void ExecuteStreamline(ResourceStreamLine streamline, Character executingCharacter);
    }
}