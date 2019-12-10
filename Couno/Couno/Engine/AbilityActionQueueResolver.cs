﻿using System;
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
                    return this.ResolveBlock(abilityAction, fight, target);
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

        private ResolveResult ResolveBlock(IAbilityToken abilityAction, ICounoFightEnvironment fight, ITarget target)
        {
            var log = new StringBuilder($"Resolving ({abilityAction})");
            var blockAmount = abilityAction.Ability.Amount;
            target.AddBlock(blockAmount);

            log.AppendLine($"Target gained block for {blockAmount}. {target.Block} remaining.");

            return new ResolveResult(log.ToString());
        }

        private ResolveResult ResolveAttack(IAbilityToken abilityAction, ICounoFightEnvironment fight, ITarget target)
        {
            var log = new StringBuilder($"Resolving ({abilityAction})");
            var damageAmount = abilityAction.Ability.Amount;

            if (target.Block > 0)
            {
                var restDamage = 0;
                if (target.Block <= damageAmount)
                {
                    restDamage += damageAmount - target.Block;
                }
                target.ReduceBlock(damageAmount);
                target.ReduceHealth(restDamage);
            }
            else
            {
                target.ReduceHealth(damageAmount);
            }

            log.AppendLine($"Target was hit for {damageAmount}. {target.Health} remaining.");

            return new ResolveResult(log.ToString());
        }
    }
}