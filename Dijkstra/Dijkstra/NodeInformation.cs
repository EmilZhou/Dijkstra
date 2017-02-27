using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class NodeInformation
    {
        private int dist;

        public int Dist
        {
            get { return dist; }
            set { dist = value; }
        }

        private NodeState staut;

        public NodeState Staut
        {
            get { return staut; }
            set { staut = value; }
        }

        public NodeInformation()
        {
            dist = int.MaxValue;
            Staut = NodeState.None;
        }

    }
}
