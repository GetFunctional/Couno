using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Media.Converters;
using Couno.Shared;

namespace Couno.Engine
{
    //public class AbilityActionBuilder
    //{

    //    IAbilityAction Create( Ability primaryAbility, Stack<Ability> ancestors, Queue<Ability> descendants)


    //}


    //public class AbilityCombiner
    //{
    //    AbilityActionsQueue CreateActionsFromAbilityQueue(Queue<Ability> abilities)
    //    {
    //        var abilityActionsQueue = new AbilityActionsQueue();
    //        var untouchedAbilities = new Queue<Ability>(abilities);
    //        var touchedAbilities = new Stack<Ability>();

    //        while (untouchedAbilities.Peek() != null)
    //        {
    //            var dequeuedAbility = untouchedAbilities.Dequeue();



    //            touchedAbilities.Push(dequeuedAbility);
    //        }

    //        return abilityActionsQueue;
    //    }
        


    //}


    public class AbilityEvaluator
    {
        //public AbilityActionsQueue Evaluate( IEnumerable<IAbilityToken> abilityToken)
        //{
        //    var abilities = ExtractAbilities(abilityToken);
        //    var k = new LinkedList<IAbilityToken>();
            
        //    foreach (var ability in abilities)
        //    {

             
                
        //    }
        //}

        //private Queue<Ability> ExtractAbilities(IAbilityToken abilityToken)
        //{
        //    CodeGuard.ArgumentNotNull(abilityToken, nameof(abilityToken));
        //    var abilityQueue = new Queue<Ability>();

        //    foreach (var ability in abilityToken.Abilities)
        //    {
        //        abilityQueue.Enqueue(ability);
        //    }

        //    if (abilityToken.Descendant != null)
        //    {
        //        var descendantAbilities = ExtractAbilities(abilityToken.Descendant);
        //        foreach (var descendantAbility in descendantAbilities)
        //        {
        //            abilityQueue.Enqueue(descendantAbility);
        //        }
        //    }

        //    return abilityQueue;
        //}
    }
}
