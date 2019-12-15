using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Couno.Engine
{
    internal class AbilityActionQueueResolver : IAbilityActionQueueResolver
    {
        public TargetSelectionRequirement GetTargetSelectionRequirement(Character character, IAbilityToken ability)
        {
            switch (ability.Ability.AbilityType)
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

        public ITarget AutoSelectTarget(Character character, IAbilityToken ability, IList<ITarget> enemiesOfTarget)
        {
            switch (ability.Ability.AbilityType)
            {
                case AbilityType.TakeAncestor:
                case AbilityType.TakeDescendant:
                case AbilityType.None:
                    return null;
                case AbilityType.Attack:
                    return enemiesOfTarget.First();
                case AbilityType.Block:
                    return character;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ResolveResult Resolve(Character character, IAbilityToken ability, IList<ITarget> targets)
        {
            switch (ability.Ability.AbilityType)
            {
                case AbilityType.None:
                    break;
                case AbilityType.Attack:
                    return this.ResolveAttack(character, ability, targets);
                case AbilityType.Block:
                    return this.ResolveBlock(character, ability);
                case AbilityType.TakeAncestor:
                    break;
                case AbilityType.TakeDescendant:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return new ResolveResult("Nothing to resolve");
        }

        private ResolveResult ResolveBlock(Character character, IAbilityToken ability)
        {
            var log = new StringBuilder($"Resolving ({ability})");
            var blockAmount = ability.Ability.Amount;

            character.AddBlock(blockAmount);
            log.AppendLine($"Target gained block for {blockAmount}.{character.Block} remaining.");

            return new ResolveResult(log.ToString());
        }

        private ResolveResult ResolveAttack(Character character, IAbilityToken ability, IList<ITarget> targets)
        {
            var log = new StringBuilder($"Resolving ({ability})");
            var damageAmount = ability.Ability.Amount;

            foreach (var target in targets)
            {
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
            }

            return new ResolveResult(log.ToString());
        }
    }
}