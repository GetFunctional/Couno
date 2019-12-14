using System;
using System.Collections.Generic;
using System.Linq;
using Couno.Engine;

namespace Couno
{
    internal class CounoTestFight : ICounoFightEnvironment
    {
        private readonly IAbilityActionQueueResolver _actionQueueResolver = new AbilityActionQueueResolver();

        public CounoTestFight(Character player, Character enemy)
        {
            Player = player;
            Enemy = enemy;
            this.ChangeActiveCharacter(player);
        }

        public Character CurrentActiveCharacter { get; private set; }

        public Character Enemy { get; }
        public event EventHandler<ActiveCharacterChangedEventArgs> ActiveCharacterChanged;
        public Character Player { get; }

        public IReadOnlyList<IAbilityToken> GetTokensFromStreamLine( ResourceStreamLine resourceStreamLine)
        {
            return resourceStreamLine.ExtractAbilities().ToList();
        }

        public TargetSelectionRequirement GetTargetSelectionRequirementForAction(Character character,
            IAbilityToken ability)
        {
            return _actionQueueResolver.GetTargetSelectionRequirement(character, ability);
        }

        public ITarget AutoSelectTargetForAction(Character character, IAbilityToken ability)
        {
            return _actionQueueResolver.AutoSelectTarget(character, ability, GetEnemyOf(character).Cast<ITarget>().ToList());
        }

        public object ResolveAbility(Character character, IAbilityToken ability, ITarget target)
        {
            return _actionQueueResolver.Resolve(character, ability, new List<ITarget> {target});
        }

        public void StartTurn(Character character)
        {
            ChangeActiveCharacter(character);
        }


        public void FinishTurn(Character character)
        {

            var enemyOfCharacter = GetEnemyOf(character);
            this.StartTurn(enemyOfCharacter.FirstOrDefault());
        }

        public bool IsItMyTurn(Character character)
        {
            return this.CurrentActiveCharacter == character;
        }

        private void ChangeActiveCharacter(Character character)
        {
            var previousActiveCharacter = CurrentActiveCharacter;
            CurrentActiveCharacter = character;
            RaiseActiveCharacterChanged(new ActiveCharacterChangedEventArgs(character, previousActiveCharacter));
        }

        internal IList<Character> GetEnemyOf(Character character)
        {
            if (character == Enemy) return new List<Character> {Player};

            return new List<Character> {Enemy};
        }

        protected virtual void RaiseActiveCharacterChanged(ActiveCharacterChangedEventArgs e)
        {
            ActiveCharacterChanged?.Invoke(this, e);
        }
    }
}