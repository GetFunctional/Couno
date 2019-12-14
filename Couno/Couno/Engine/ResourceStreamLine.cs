using System.Collections.Generic;
using System.Linq;

namespace Couno.Engine
{
    public sealed class ResourceStreamLine : IResourceStreamlineElement
    {
        public ResourceStreamLine()
        {
            this.StreamlineElements = new List<IResourceStreamlineElement>();
        }

        public IList<IResourceStreamlineElement> StreamlineElements { get; }

        #region IResourceStreamlineElement Members

        public IEnumerable<IAbilityToken> ExtractAbilities()
        {
            return this.StreamlineElements.SelectMany(x => x.ExtractAbilities());
        }

        #endregion

        internal void AddElement(IResourceStreamlineElement element)
        {
            this.StreamlineElements.Add(element);
        }
    }
}