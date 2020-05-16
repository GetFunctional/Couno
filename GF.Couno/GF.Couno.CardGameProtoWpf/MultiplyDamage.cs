namespace GF.Couno.CardGameProtoWpf
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