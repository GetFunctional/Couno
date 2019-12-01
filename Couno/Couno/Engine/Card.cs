using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Media.Converters;
using Couno.Shared;

namespace Couno.Engine
{
    public class AbilityActionBuilder
    {

        IAbilityAction Create( Ability primaryAbility, Stack<Ability> ancestors, Queue<Ability> descendants)


    }


    public class AbilityCombiner
    {
        AbilityActionsQueue CreateActionsFromAbilityQueue(Queue<Ability> abilities)
        {
            var abilityActionsQueue = new AbilityActionsQueue();
            var untouchedAbilities = new Queue<Ability>(abilities);
            var touchedAbilities = new Stack<Ability>();

            while (untouchedAbilities.Peek() != null)
            {
                var dequeuedAbility = untouchedAbilities.Dequeue();



                touchedAbilities.Push(dequeuedAbility);
            }

            return abilityActionsQueue;
        }
        


    }


    public class AbilityEvaluator
    {

        AbilityActionsQueue Evaluate(IAbilityToken abilityToken)
        {
            var abilities = ExtractAbilities(abilityToken);


            foreach (var ability in abilities)
            {

             
                
            }
        }

        private Queue<Ability> ExtractAbilities(IAbilityToken abilityToken)
        {
            CodeGuard.ArgumentNotNull(abilityToken, nameof(abilityToken));
            var abilityQueue = new Queue<Ability>();

            foreach (var ability in abilityToken.Abilities)
            {
                abilityQueue.Enqueue(ability);
            }

            if (abilityToken.Descendant != null)
            {
                var descendantAbilities = ExtractAbilities(abilityToken.Descendant);
                foreach (var descendantAbility in descendantAbilities)
                {
                    abilityQueue.Enqueue(descendantAbility);
                }
            }

            return abilityQueue;
        }
    }

    internal interface IAbilityToken
    {
        IAbilityToken Ancestor { get; }

        IAbilityToken Descendant { get; }

        IList<Ability> Abilities { get; }
    }

    internal class Ability
    {
        int Amount { get; }

        string Name { get; }

        private AbilityType AbilityType { get; }
    }

    internal enum AbilityType
    {
        None = 0,
        Attack = 1,
        Block = 2,
        TakeAncestor = 3,
        TakeDescendant = 4,
    }

    public class AbilityActionsQueue
    {
        private Queue<IAbilityAction> Actions { get; }

    }

    internal interface IAbilityAction
    {
        Queue<IAbilityToken> AbilityTokens { get; }


    }


    public class Card
    {
        public string Name { get; }

        public IList<Effect> Effects { get; }
    }

    public class Character
    {

        public string Name { get; }

        public int Life { get; private set; }

    }

    public class ChakraBoard
    {

        public Character Owner { get; }

        private ICollection<ChakraNode> Nodes { get; }
    }

    internal class ChakraNode
    {

        public string Name { get; }

        public IList<Effect> Effects { get; }

        public ICollection<ChakraNode> Childs { get; }
    }


    public class Player
    {
        public CardDeck DrawDeck { get; }

        public CardDeck DiscardPile { get; }

        public CardDeck LostPile { get; }

        public Party Party { get; set; }

    }

    public class Party
    {
        // List of Characters

    }

    public class CardDeck
    {
        // Stack of Cards
        // Draw
        // Put
        // Shuffle
    }

}
