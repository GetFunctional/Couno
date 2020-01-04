using System.Collections.Generic;
using System.Linq;
using GF.Couno.Core.ResourceSystem;

namespace GF.Couno.Core.CardSysten
{
    public class CardCost
    {
        public CardCost(IEnumerable<PowerResource> resourceCost)
        {
            this.ResourceCost = resourceCost.ToList();
        }

        public IReadOnlyList<PowerResource> ResourceCost { get; }
    }
}