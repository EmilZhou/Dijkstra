namespace Dijkstra
{
    public class NodeInformation
    {
        private int dist;
        private NodeState staut;
        private Node viaNode;

        /// <summary>
        /// The dist to start node
        /// </summary>
        public int Dist
        {
            get { return dist; }
            set { dist = value; }
        }

        /// <summary>
        /// The staut of this node
        /// </summary>
        public NodeState Staut
        {
            get { return staut; }
            set { staut = value; }
        }

        /// <summary>
        /// The prev node to start node
        /// </summary>
        public Node ViaNode
        {
            get { return viaNode; }
            set { viaNode = value; }
        }

        public NodeInformation()
        {
            dist = int.MaxValue;
            Staut = NodeState.None;
        }

    }
}
