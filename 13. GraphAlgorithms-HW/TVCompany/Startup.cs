namespace TVCompany
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        //You are given a cable TV company.The company needs to lay cable to a new neighborhood(for every house).
        //If it is constrained to bury the cable only along certain paths,
        //then there would be a graph representing which points are connected by those paths.
        //But the cost of some of the paths is more expensive because they are longer.
        //If every house is a node and every path from house to house is an edge, find a way to minimize the cost for cables.

        static string inputWeightGraph = @"0 3 7
0 4 3 
0 5 5
1 2 10
1 3 2
1 4 1
2 4 100
2 5 17
3 4 1
4 5 3";
        static int n = 6;
        static List<WeightedNode>[] vertices = new List<WeightedNode>[n];

        public static void Main()
        {
            Dijkstra();
        }

        public class WeightedNode : IComparable<WeightedNode>
        {
            public WeightedNode(int vertex, int weight)
            {
                this.Vertex = vertex;
                this.Weight = weight;
            }

            public int Vertex { get; set; }
            public int Weight { get; set; }

            public int CompareTo(WeightedNode other)
            {
                if (this.Weight.CompareTo(other.Weight) == 0)
                {
                    return this.Vertex.CompareTo(other.Vertex);
                }
                return this.Weight.CompareTo(other.Weight);
            }
        }

        private static void Dijkstra()
        {
            int v = 0;
            List<WeightedNode>[] vertices = ReadInput(inputWeightGraph);

            var visited = new HashSet<int>();
            var queue = new SortedSet<WeightedNode>();
            int[] d = Enumerable.Repeat(int.MaxValue, vertices.Length)
                .ToArray();

            d[v] = 0;
            queue.Add(new WeightedNode(v, 0));

            var path = new int[vertices.Length];
            path[v] = -1;

            while (queue.Count > 0)
            {
                var current = queue.Min;
                queue.Remove(current);
                visited.Add(current.Vertex);
                // calculate distance

                foreach (var neighbour in vertices[current.Vertex])
                {
                    var currentD = d[neighbour.Vertex];
                    var newD = d[current.Vertex] + neighbour.Weight;
                    if (currentD > newD)
                    {
                        d[neighbour.Vertex] = newD;
                        queue.Add(new WeightedNode(neighbour.Vertex, newD));
                        path[neighbour.Vertex] = current.Vertex;
                    }
                }

                //remove top visited
                while (queue.Count > 0 && visited.Contains(queue.Min.Vertex))
                {
                    queue.Remove(queue.Min);
                }
            }
            var sumAll = d.Sum();
            Console.WriteLine("Sum all min paths from 0 node: " + sumAll);

            for (int i = 0; i < d.Length; i++)
            {
                if (path[i] > 0)
                {
                    sumAll -= d[path[i]];
                }
                Console.WriteLine("from 0 house to {0} -> {1} through {2}", i, d[i], path[i]);
            }

            Console.WriteLine("Minimal cost of cables: " + sumAll);
        }

        private static List<WeightedNode>[] ReadInput(string input)
        {
            var edges = input.Split('\n').ToArray();
            foreach (var edge in edges)
            {
                var parts = edge.Split(' ');
                var v1 = int.Parse(parts[0]);
                var v2 = int.Parse(parts[1]);
                var w = int.Parse(parts[2]);

                if (vertices[v1] == null)
                {
                    vertices[v1] = new List<WeightedNode>();
                }

                if (vertices[v2] == null)
                {
                    vertices[v2] = new List<WeightedNode>();
                }
                vertices[v1].Add(new WeightedNode(v2, w));
                vertices[v2].Add(new WeightedNode(v1, w));
            }
            return vertices;
        }
    }
}
