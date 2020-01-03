using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GF.Couno.Core
{
    public class FightRuleSet
    {

    }

    public class Fight
    {
        // Played Cards Queue<Card>
    }

    public class FightCardResolver
    {
        public void ResolveCard(Card card, Fight fight)
        {

        }
    }

    public class Card
    {
        public Card(IList<CardEffect> cardEffects)
        {
            this.CardEffects = cardEffects;
        }

        public IList<CardEffect> CardEffects { get; }

    }

    public class CardEffect
    {
        public CardEffect(EffectType effectType, int amount)
        {
            this.EffectType = effectType;
            this.Amount = amount;
        }

        public int Amount { get; }

        public EffectType EffectType { get; }

    }


    public enum EffectType
    {
        None = 0,
        Attack = 1,
        Block = 2,
        Weaken = 3,
        Break = 4,
        Heal = 5,

    
    }
}
