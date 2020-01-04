using System;

namespace GF.Couno.Core.ResourceSystem
{
    public static class PowerResourceExtensions
    {
        public static PowerResource MergeResources(this PowerResource pwr1, PowerResource pwr2)
        {
            if (pwr1.PowerColor != pwr2.PowerColor)
            {
                throw new ArgumentException("Cannot merge different PowerResources.");
            }

            return new PowerResource(pwr1.Amount + pwr2.Amount, pwr1.PowerColor);
        }
    }
}