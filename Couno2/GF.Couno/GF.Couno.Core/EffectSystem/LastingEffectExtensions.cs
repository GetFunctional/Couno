using System;

namespace GF.Couno.Core.EffectSystem
{
    public static class LastingEffectExtensions
    {
        public static LastingEffect MergeEffects(this LastingEffect le1, LastingEffect le2)
        {
            if (le1.EffectType != le2.EffectType)
            {
                throw new ArgumentException("Cannot merge different Effects.");
            }

            return new LastingEffect(le1.Duration + le2.Duration, le1.EffectType);
        }
    }
}