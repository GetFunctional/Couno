using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace GF.Couno.Core.EffectSystem
{
    public class LastingEffects
    {
        private readonly ConcurrentDictionary<EffectType, LastingEffect> _lastingEffects =
            new ConcurrentDictionary<EffectType, LastingEffect>();

        public LastingEffects() : this(Enumerable.Empty<LastingEffect>())
        {
        }

        public LastingEffects(IEnumerable<LastingEffect> lastingEffects)
        {
            this.AddEffects(this.CreateDefaultEffects().Concat(lastingEffects));
        }

        public IReadOnlyList<LastingEffect> Effects
        {
            get { return this._lastingEffects.Select(x => x.Value).ToList(); }
        }

        private IEnumerable<LastingEffect> CreateDefaultEffects()
        {
            foreach (var value in Enum.GetValues(typeof(EffectType)).Cast<EffectType>().Except(new[] {EffectType.None}))
            {
                yield return new LastingEffect(0, value);
            }
        }

        private void AddEffects(IEnumerable<LastingEffect> effects)
        {
            foreach (var effect in effects.GroupBy(x => x.EffectType))
            {
                this.AddEffectInternal(new LastingEffect(effects.Sum(x => x.Duration),
                    effect.Key));
            }
        }

        private void AddEffectInternal(LastingEffect effect)
        {
            this.CheckEffect(effect.EffectType);

            var currentValue = this._lastingEffects.GetOrAdd(effect.EffectType, this.CreateDefault);
            if (!this._lastingEffects.TryUpdate(effect.EffectType, effect.MergeEffects(effect),
                currentValue))
            {
                throw new InvalidOperationException("Could not update the new Powerresource Value.");
            }
        }

        private void CheckEffect(EffectType effectType)
        {
            if (IsValidEffect(effectType))
            {
                throw new ArgumentException("None is not a valid effect");
            }
        }

        private static bool IsValidEffect(EffectType effectType)
        {
            return effectType == EffectType.None;
        }

        public int DurationOf(EffectType effectType)
        {
            this.CheckEffect(effectType);

            return this._lastingEffects[effectType].Duration;
        }


        private LastingEffect CreateDefault(EffectType effectType)
        {
            return new LastingEffect(0, effectType);
        }

        public void AddEffect(LastingEffect effect)
        {
            this.AddEffects(new[] {effect});
        }

        public bool HasEffect(EffectType effect)
        {
            return this.DurationOf(effect) > 0;
        }
    }
}