namespace GF.Couno.CardGameProtoWpf
{
    internal class HealSelf : IEffect
    {
        public int Amount { get; }

        public HealSelf(int amount)
        {
            Amount = amount;
            EffectTarget = EffectTarget.Self;
        }

        public EffectTarget EffectTarget { get; }
    }
}