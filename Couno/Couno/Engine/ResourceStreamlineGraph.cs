using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Couno.Shared;

namespace Couno.Engine
{
    public sealed class ResourceStreamlineGraph
    {
        private readonly ISet<IResourceStreamlineElement> _allElements = new HashSet<IResourceStreamlineElement>();

        private readonly Dictionary<IResourceStreamlineElement, ISet<IResourceStreamlineElement>> _elementChildren =
            new Dictionary<IResourceStreamlineElement, ISet<IResourceStreamlineElement>>();

        private readonly Dictionary<IResourceStreamlineElement, ISet<IResourceStreamlineElement>> _elementParents =
            new Dictionary<IResourceStreamlineElement, ISet<IResourceStreamlineElement>>();

        private readonly List<ResourceStreamLine> _streamlines;

        public ResourceStreamlineGraph()
        {
            this._streamlines = new List<ResourceStreamLine>();
        }

        public IReadOnlyList<ResourceStreamLine> Streamlines
        {
            get { return this._streamlines; }
        }

        public void AddStreamline(ResourceStreamLine streamline)
        {
            this.EnsureElementInludedInCycle(streamline);
            this._streamlines.Add(streamline);
        }

        public void AddElement(ResourceStreamLine streamline, IResourceStreamlineElement element)
        {
            this.EnsureElementInludedInCycle(streamline);
            this.EnsureElementInludedInCycle(element);

            this.ConnectAsChildOf(streamline, element);
            streamline.AddElement(element);
        }

        private void ConnectAsChildOf(IResourceStreamlineElement parent, IResourceStreamlineElement child)
        {
            this._elementChildren[parent].Add(child);
            this._elementParents[child].Add(parent);
        }

        private IReadOnlyCollection<IResourceStreamlineElement> GetElementsOnLevel(int level)
        {
            var elementsOnNextLevel =
                this._elementParents.Where(x => x.Value.IsEmpty()).SelectMany(x => x.Value).ToHashSet();

            for (var counter = 0; counter < level; counter++)
            {
                elementsOnNextLevel =
                    new HashSet<IResourceStreamlineElement>(elementsOnNextLevel
                        .SelectMany(x => this._elementChildren[x]).Distinct());
            }

            return elementsOnNextLevel;
        }

        public IEnumerable<IResourceStreamlineElement> GetStreamlineElements(ResourceStreamLine streamline)
        {
            return this.GetStreamlineElementsRecursive(streamline);
        }

        private IEnumerable<IResourceStreamlineElement> GetStreamlineElementsRecursive(
            IResourceStreamlineElement element)
        {
            return element.Yield()
                .Concat(this._elementChildren[element].SelectMany(this.GetStreamlineElementsRecursive));
        }


        private void EnsureElementInludedInCycle(IResourceStreamlineElement elementToConnect)
        {
            if (!this._allElements.Contains(elementToConnect))
            {
                this._allElements.Add(elementToConnect);
                this._elementParents.Add(elementToConnect, new HashSet<IResourceStreamlineElement>());
                this._elementChildren.Add(elementToConnect, new HashSet<IResourceStreamlineElement>());
            }
        }

        public void ResolveStreamline(ResourceStreamLine streamline)
        {
            var level = 0;
            while (true)
            {
                var resourcesLeft = streamline.
                var elementsOnLevel = GetElementsOnLevel(level);
                if (!elementsOnLevel.Any())
                {
                    return;
                }
                
            }
        }
    }
}