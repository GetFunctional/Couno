namespace Couno.Engine
{
    public class CounoEngine
    {
        private readonly ResourceElementFactory _resourceElementFactory;

        public CounoEngine(ResourceElementFactory resourceElementFactory)
        {
            this._resourceElementFactory = resourceElementFactory;
            this.StreamlineGraph = this._resourceElementFactory.BuildDefaultPlayerStreamlineGraph();
        }

        public ResourceStreamlineGraph StreamlineGraph { get; }
    }
}