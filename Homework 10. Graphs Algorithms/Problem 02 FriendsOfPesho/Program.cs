namespace Problem_02_FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Program
    {
        private static int houseCount;
        private static int streetCount;
        private static int hospitalCount;
        private bool[] vistited;

        static void Main()
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var hospitalLocs = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var graph = new Dictionary<Node, List<Point>>();

            for (int i = 0; i < input[1]; i++)
            {
                var currentPoints = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
                var nodeA = new Node(currentPoints[0]);
                if (graph.ContainsKey(nodeA))
                {
                    graph[nodeA].Add(new Point(nodeA, currentPoints[2]));
                }
                else
                {
                    graph.Add(nodeA, new List<Point>() { new Point(nodeA, currentPoints[2]) });
                }

            }

        }

        private static void DijkstraAlgorithm(Dictionary<Node, List<Point>> graph, Node source)
        {
            var queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = double.PositiveInfinity;
            }

            source.DijkstraDistance = 0.0d;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                var currentNode = queue.Dequeue();

                if (double.IsPositiveInfinity(currentNode.DijkstraDistance))
                {
                    break;
                }

                foreach (var neighbor in graph[currentNode])
                {
                    var potDistance = currentNode.DijkstraDistance + neighbor.Distance;
                    if (potDistance < neighbor.Node.DijkstraDistance)
                    {
                        neighbor.Node.DijkstraDistance = potDistance;
                        queue.Enqueue(neighbor.Node);
                    }
                }
            }
        }

    }
}

