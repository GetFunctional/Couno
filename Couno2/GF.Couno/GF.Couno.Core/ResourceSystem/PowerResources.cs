using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace GF.Couno.Core.ResourceSystem
{
    public sealed class PowerResources
    {
        private readonly ConcurrentDictionary<PowerColor, PowerResource> _availableResources;

        public PowerResources() : this(Enumerable.Empty<PowerResource>())
        {
        }

        public PowerResources(IEnumerable<PowerResource> availableResources)
        {
            this._availableResources = this.CreatePowerResourceList(availableResources);
        }

        public IReadOnlyList<PowerResource> AvailableResources
        {
            get { return this._availableResources.Select(x => x.Value).ToList(); }
        }

        private ConcurrentDictionary<PowerColor, PowerResource> CreatePowerResourceList(
            IEnumerable<PowerResource> availableResources)
        {
            var resourceTypes = new ConcurrentDictionary<PowerColor, PowerResource>();
            foreach (PowerColor availablePowerColor in Enum.GetValues(typeof(PowerColor)))
            {
                var powerResource =
                    new PowerResource(
                        availableResources.Where(x => x.PowerColor == availablePowerColor).Sum(x => x.Amount),
                        availablePowerColor);
                resourceTypes.TryAdd(availablePowerColor, powerResource);
            }

            return resourceTypes;
        }

        public int AvailableAmountOf(PowerColor color)
        {
            return this._availableResources[color].Amount;
        }

        public void AddResource(PowerResource resource)
        {
            var currentValue = this._availableResources[resource.PowerColor];
            if (!this._availableResources.TryUpdate(resource.PowerColor, currentValue.MergeResources(resource),
                currentValue))
            {
                throw new InvalidOperationException("Could not update the new Powerresource Value.");
            }
        }

        public bool HasResource(PowerColor color)
        {
            return this.AvailableAmountOf(color) > 0;
        }
    }
}