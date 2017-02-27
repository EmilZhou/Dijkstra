using System;
using System.Collections.Generic;
using System.Linq;

namespace BidirectionalDijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates nodes.
            List<Node> nodes = CreateSampleNodes();

            // Sets the Start-End
            int startNodeIndex = 0;
            int endNodeIndex = 4;

            // Runs Dijkstra
            BidirectionalDijkstra(nodes[startNodeIndex], nodes[endNodeIndex]);

            Console.ReadKey(true);
        }

        private static void BidirectionalDijkstra(Node source, Node target)
        {
            // Sets start node distance to 0, including positive and reverse NodeInformation.
            foreach (NodeInformation information in source.NodeInformations)
            {
                information.Dist = 0;
            }

            foreach (NodeInformation information in target.NodeInformations)
            {
                information.Dist = 0;
            }

            // Creates the stacks including positive direction and reverse direction
            List<Stack<Node>> stacks = new List<Stack<Node>>();
            Stack<Node> positiveDirectionStack = new Stack<Node>();
            Stack<Node> reverseDirectionStack = new Stack<Node>();

            positiveDirectionStack.Push(source);
            reverseDirectionStack.Push(target);

            stacks.Add(positiveDirectionStack);
            stacks.Add(reverseDirectionStack);

            // Is positive and reverse visited the same node
            bool intersect = false;

            // The stack index, be used to switch positive and reverse.
            int stackIndex = 0;

            while (!intersect)
            {
                // Takes turns to get positive or reverse stack as current direction stack.
                Stack<Node> stack = stacks[stackIndex];

                // Gets the top of current direction stack which the distance is smallest.
                Node v = stack.Pop();

                // Gets the information of positive or reverse as current direction information.
                NodeInformation vi = v.NodeInformations[stackIndex];

                // Sets the staut of the current direction information to Select.
                vi.Staut = NodeState.Select;

                // whether positive and reverse has met
                if (v.Done)
                {
                    //positive and reverse has met
                    intersect = true;
                    // TODO: return the path.
                    Console.WriteLine("Bingo: positive and reverse Direction has met");
                }
                else
                {
                    // positive and reverse has not met

                    // Gets the edges of current node.
                    var edges = v.Edges;
                    // Visits each edges.
                    foreach (Edge edge in edges)
                    {
                        // Gets the adjacent nodes of current node.
                        Node w = edge.TargetNode;
                        // Gets the current direction information of adjacent nodes. 
                        NodeInformation wi = w.NodeInformations[stackIndex];

                        // whether this adjacent node is selected. if it is selected it is the shortest path.
                        if (wi.Staut != NodeState.Select)
                        {
                            // the adjacent node did not selecte. update the distance.
                            int visiedLength = edge.Length + vi.Dist;
                            if (visiedLength < wi.Dist)
                            {
                                wi.Dist = visiedLength;
                            }

                            // Push if the adjacent is no longer stack
                            if (wi.Staut != NodeState.Active)
                            {
                                wi.Staut = NodeState.Active;
                                stack.Push(w);
                            }
                        }
                    }
                    // Orders the stack
                    var sortedNode = stack.OrderByDescending(n => n.NodeInformations[stackIndex].Dist);
                    stack = new Stack<Node>(sortedNode);

                    // Switchs the direction
                    if (stackIndex == 0)
                    {
                        stackIndex = 1;
                    }
                    else
                    {
                        stackIndex = 0;
                    }
                }
            }
        }

        private static List<Node> CreateSampleNodes()
        {
            List<Node> nodes = new List<Node>();

            Node node1 = new Node();
            Node node2 = new Node();
            Node node3 = new Node();
            Node node4 = new Node();
            Node node5 = new Node();
            Node node6 = new Node();

            node1.Id = 1;
            node2.Id = 2;
            node3.Id = 3;
            node4.Id = 4;
            node5.Id = 5;
            node6.Id = 6;

            node1.Name = node1.Id.ToString();
            node2.Name = node2.Id.ToString();
            node3.Name = node3.Id.ToString();
            node4.Name = node4.Id.ToString();
            node5.Name = node5.Id.ToString();
            node6.Name = node6.Id.ToString();
            Console.WriteLine("Here are 6 nodes, and the following is the edges ");
            Console.WriteLine("Start | End | length");

            node1.AddAdjacentNode(node2, 7);
            Console.WriteLine("  1  |  2  |  7 ");

            node1.AddAdjacentNode(node3, 9);
            Console.WriteLine("  1  |  3  |  9 ");

            node1.AddAdjacentNode(node6, 14);
            Console.WriteLine("  1  |  6  |  14 ");


            node2.AddAdjacentNode(node1, 7);
            Console.WriteLine("  2  |  1  |  7 ");

            node2.AddAdjacentNode(node3, 10);
            Console.WriteLine("  2  |  3  |  10 ");

            node2.AddAdjacentNode(node4, 15);
            Console.WriteLine("  2  |  4  |  15 ");


            node3.AddAdjacentNode(node1, 9);
            Console.WriteLine("  3  |  1  |  9 ");


            node3.AddAdjacentNode(node2, 10);
            Console.WriteLine("  3  |  2  |  10 ");

            node3.AddAdjacentNode(node4, 11);
            Console.WriteLine("  3  |  4  |  11 ");

            node3.AddAdjacentNode(node6, 2);
            Console.WriteLine("  3  |  6  |  2 ");


            node4.AddAdjacentNode(node2, 15);
            Console.WriteLine("  4  |  2  |  15 ");

            node4.AddAdjacentNode(node3, 11);
            Console.WriteLine("  4  |  3  |  11 ");

            node4.AddAdjacentNode(node5, 6);
            Console.WriteLine("  4  |  5  |  6 ");


            node5.AddAdjacentNode(node4, 6);
            Console.WriteLine("  5  |  4  |  6 ");

            node5.AddAdjacentNode(node6, 9);
            Console.WriteLine("  5  |  6  |  9 ");


            node6.AddAdjacentNode(node1, 14);
            Console.WriteLine("  6  |  1  |  14 ");

            node6.AddAdjacentNode(node3, 2);
            Console.WriteLine("  6  |  3  |  2 ");

            node6.AddAdjacentNode(node5, 9);
            Console.WriteLine("  6  |  5  |  9 ");

            nodes.Add(node1);
            nodes.Add(node2);
            nodes.Add(node3);
            nodes.Add(node4);
            nodes.Add(node5);
            nodes.Add(node6);

            return nodes;
        }
    }
}
