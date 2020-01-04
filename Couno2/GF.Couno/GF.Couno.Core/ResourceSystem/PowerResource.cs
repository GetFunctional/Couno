namespace GF.Couno.Core.ResourceSystem
{
    public sealed class PowerResource
    {
        public PowerResource(int amount, PowerColor powerColor)
        {
            this.Amount = amount;
            this.PowerColor = powerColor;
        }

        public int Amount { get; }

        public PowerColor PowerColor { get; }
    }
}