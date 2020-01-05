using GF.Couno.Core.ResourceSystem;

namespace GF.Couno.Core.EffectSystem
{
    public class LastingEffect
    {
        public LastingEffect(int duration, EffectType effectType)
        {
            this.Duration = duration;
            this.EffectType = effectType;
        }

        public int Duration { get; }

        public EffectType EffectType { get; }
    }
}