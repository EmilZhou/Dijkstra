using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class Node
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<NodeInformation> nodeInformations;

        public List<NodeInformation> NodeInformations
        {
            get
            {
                return nodeInformations;
            }
        }

        public bool Done
        {
            get
            {
                foreach (var information in NodeInformations)
                {
                    if (information.Staut != NodeState.Select)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public Node()
        {
            nodeInformations = new List<NodeInformation>();
            nodeInformations.Add(new NodeInformation());
            nodeInformations.Add(new NodeInformation());
        }

        private List<Edge> edges;

        public List<Edge> Edges
        {
            get
            {
                if (edges == null)
                {
                    edges = new List<Edge>();
                }
                return edges;
            }
            set { edges = value; }
        }

        public void AddAdjacentNode(Node target, int length)
        {
            Edge edge = new Edge(this, target, length);
            Edges.Add(edge);
        }

    }
}
