using System;
using System.Text;
using System.Windows.Markup;

namespace Couno.Engine
{
    internal class AbilityActionQueueResolver : IAbilityActionQueueResolver
    {
        public TargetSelectionRequirement GetTargetSelectionRequirement(IAbilityToken abilityAction, ICounoFightEnvironment fight)
        {
            switch (abilityAction.Ability.AbilityType)
            {
                case AbilityType.TakeAncestor:
                case AbilityType.TakeDescendant:
                case AbilityType.None:
                    return TargetSelectionRequirement.NoTargetRequired;
                case AbilityType.Attack:
                    return TargetSelectionRequirement.EnemyTargetSelectionRequired;
                case AbilityType.Block:
                    return TargetSelectionRequirement.FriendlyTargetSelectionRequired;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ITarget AutoSelectTarget(IAbilityToken abilityAction, ICounoFightEnvironment fight)
        {
            switch (abilityAction.Ability.AbilityType)
            {
                case AbilityType.TakeAncestor:
                case AbilityType.TakeDescendant:
                case AbilityType.None:
                    return null;
                case AbilityType.Attack:
                    return fight.Enemy;
                case AbilityType.Block:
                    return fight.Player;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ResolveResult Resolve(IAbilityToken abilityAction, ICounoFightEnvironment fight, ITarget target)
        {
            switch (abilityAction.Ability.AbilityType)
            {
                case AbilityType.None:
                    break;
                case AbilityType.Attack:
                    return this.ResolveAttack(abilityAction, fight, target);
                    break;
                case AbilityType.Block:
                    break;
                case AbilityType.TakeAncestor:
                    break;
                case AbilityType.TakeDescendant:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new ResolveResult("Nothing to resolve");
        }

        private ResolveResult ResolveAttack(IAbilityToken abilityAction, ICounoFightEnvironment fight, ITarget target)
        {
            var log = new StringBuilder($"Resolving Attack ({abilityAction})");
            var damageAmount = abilityAction.Ability.Amount;
            target.ReduceHealth(damageAmount);

            log.AppendLine($"Target was hit for {damageAmount}. {target.Health} remaining.");

            return new ResolveResult(log.ToString());
        }
    }
}