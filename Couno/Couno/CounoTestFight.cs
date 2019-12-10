using System.Collections.Generic;
using Couno.Engine;

namespace Couno
{
    internal class CounoTestFight : ICounoFightEnvironment
    {
        private readonly IAbilityActionQueueResolver _actionQueueResolver = new AbilityActionQueueResolver();

        public CounoTestFight(Character player, Character enemy)
        {
            this.Player = player;
            this.Enemy = enemy;
        }

        public Character Enemy { get; }
        public Character Player { get; }

        public TargetSelectionRequirement GetTargetSelectionRequirementForAction(Character character, IAbilityToken ability)
        {
            return _actionQueueResolver.GetTargetSelectionRequirement(character, ability);
        }

        public ITarget AutoSelectTargetForAction(Character character, IAbilityToken ability)
        {
            return _actionQueueResolver.AutoSelectTarget(character, ability, GetEnemyOf(character));
        }

        public object ResolveAbility(Character character, IAbilityToken ability, ITarget target)
        {
            return _actionQueueResolver.Resolve(character, ability, new List<ITarget>() { target });

        }

        internal IList<ITarget> GetEnemyOf(Character character)
        {
            if (character == this.Enemy) return new List<ITarget> { this.Player };

            return new List<ITarget> { Enemy };
        }

    }
}