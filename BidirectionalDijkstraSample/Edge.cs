namespace BidirectionalDijkstra
{
    public class Edge
    {
        private Node sourceNode;

        public Node SourceNode
        {
            get { return sourceNode; }
            set { sourceNode = value; }
        }

        private Node targetNode;

        public Node TargetNode
        {
            get { return targetNode; }
            set { targetNode = value; }
        }

        private int length;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        public Edge(Node source, Node target, int length)
        {
            this.SourceNode = source;
            this.TargetNode = target;
            this.Length = length;
        }
    }
}
