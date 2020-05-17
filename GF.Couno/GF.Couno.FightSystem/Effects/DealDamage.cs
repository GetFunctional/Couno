namespace GF.Couno.FightSystem.Effects
{
    public class DealDamage : IEffect
    {
        public DealDamage(int amountDamage)
        {
            AmountDamage = amountDamage;
            this.EffectTarget = EffectTarget.AllEnemies;
        }

        public int AmountDamage { get; }

        public EffectTarget EffectTarget { get; }
    }
}