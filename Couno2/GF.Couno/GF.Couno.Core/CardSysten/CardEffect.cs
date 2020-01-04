using GF.Couno.Core.EffectSystem;

namespace GF.Couno.Core.CardSysten
{
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
}
