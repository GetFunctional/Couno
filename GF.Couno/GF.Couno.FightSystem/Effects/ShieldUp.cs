namespace GF.Couno.FightSystem.Effects
{
    internal class ShieldUp : IEffect
    {
        public int Amount { get; }

        public ShieldUp(int amount)
        {
            Amount = amount;
            EffectTarget = EffectTarget.Self;
        }

        public EffectTarget EffectTarget { get; }
    }
}