using System.Collections.Generic;
using System.Linq;
using GF.Couno.Core.ResourceSystem;

namespace GF.Couno.Core.CardSysten
{
    public class CardCost
    {
        public CardCost() : this(Enumerable.Empty<PowerResource>())
        {
        }

        public CardCost(IEnumerable<PowerResource> resourceCost)
        {
            this.TotalResourceCost = new PowerResources(resourceCost);
        }

        public PowerResources TotalResourceCost { get; }
    }
}