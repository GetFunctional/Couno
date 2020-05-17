namespace GF.Couno.FightSystem.Effects
{
    public class HealSelf : IEffect
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