namespace GF.Couno.FightSystem.Effects
{
    internal class MultiplyDamage : IEffect
    {
        public int Amount { get; }

        public MultiplyDamage(int amount)
        {
            Amount = amount;
            EffectTarget = EffectTarget.Self;
        }

        public EffectTarget EffectTarget { get; }
    }
}