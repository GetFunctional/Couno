using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace GF.Couno.Core.ResourceSystem
{
    public sealed class PowerResources
    {
        private readonly ConcurrentDictionary<PowerColor, PowerResource> _availableResources =
            new ConcurrentDictionary<PowerColor, PowerResource>();

        public PowerResources() : this(Enumerable.Empty<PowerResource>())
        {
        }

        public PowerResources(IEnumerable<PowerResource> availableResources)
        {
            this.AddResources(this.CreateDefaultPowerResources().Concat(availableResources));
        }

        public IReadOnlyList<PowerResource> AvailableResources
        {
            get { return this._availableResources.Select(x => x.Value).ToList(); }
        }

        private IEnumerable<PowerResource> CreateDefaultPowerResources()
        {
            foreach (var value in Enum.GetValues(typeof(PowerColor)).Cast<PowerColor>().Except(new[] {PowerColor.None}))
            {
                yield return new PowerResource(0, value);
            }
        }

        private void AddResources(IEnumerable<PowerResource> resources)
        {
            foreach (var availablePowerColor in resources.GroupBy(x => x.PowerColor))
            {
                this.AddResourceInternal(new PowerResource(availablePowerColor.Sum(x => x.Amount),
                    availablePowerColor.Key));
            }
        }

        private void AddResourceInternal(PowerResource resource)
        {
            CheckResourceColor(resource.PowerColor);

            var currentValue = this._availableResources.GetOrAdd(resource.PowerColor, this.CreateDefault);
            if (!this._availableResources.TryUpdate(resource.PowerColor, currentValue.MergeResources(resource),
                currentValue))
            {
                throw new InvalidOperationException("Could not update the new Powerresource Value.");
            }
        }

        private static void CheckResourceColor(PowerColor powerColor)
        {
            if (IsValidPowerColor(powerColor))
            {
                throw new ArgumentException("None is not a valid powerColor");
            }
        }

        private static bool IsValidPowerColor(PowerColor powerColor)
        {
            return powerColor == PowerColor.None;
        }

        private PowerResource CreateDefault(PowerColor powerColor)
        {
            return new PowerResource(0, powerColor);
        }

        public int AvailableAmountOf(PowerColor color)
        {
            CheckResourceColor(color);

            return this._availableResources[color].Amount;
        }

        public void AddResource(PowerResource resource)
        {
            this.AddResources(new[] {resource});
        }

        public bool HasResource(PowerColor color)
        {
            return this.AvailableAmountOf(color) > 0;
        }
    }
}