namespace Couno.Engine
{
    public class ResourceElementFactory
    {
        public ResourceGenerator CreateResourceGenerator(ResourceType resourceType, int amount)
        {
            return new ResourceGenerator(resourceType, amount);
        }

        public ResourceStreamlineGraph BuildDefaultPlayerStreamlineGraph()
        {
            var streamlineGraph = new ResourceStreamlineGraph();

            var redStreamLine = new ResourceStreamLine();
            var greenStreamLine = new ResourceStreamLine();
            var blueStreamLine = new ResourceStreamLine();

            streamlineGraph.AddStreamline(redStreamLine);
            streamlineGraph.AddStreamline(greenStreamLine);
            streamlineGraph.AddStreamline(blueStreamLine);

            streamlineGraph.AddElement(redStreamLine, this.CreateResourceGenerator(ResourceType.Red, 6));
            streamlineGraph.AddElement(greenStreamLine, this.CreateResourceGenerator(ResourceType.Green, 6));
            streamlineGraph.AddElement(blueStreamLine, this.CreateResourceGenerator(ResourceType.Blue, 6));

            streamlineGraph.AddElement(redStreamLine, this.CreateAbilitySocket(4));
            return streamlineGraph;
        }

        private IResourceStreamlineElement CreateAbilitySocket(int amountOfSockets)
        {
            return new TokenBoard(new TokenBoardLayout(amountOfSockets));
        }
    }
}