namespace FriendsOfPesho
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static List<Vertex>[] vertices;
        static int[] hospitals;
        public static void Main()
        {
            var PointsStreetsHospitals = Console.ReadLine().Split().Select(int.Parse).ToArray();

            hospitals = Console.ReadLine().Split().Select(int.Parse).ToArray();

            ReadInput(PointsStreetsHospitals[0], PointsStreetsHospitals[1]);

            int bestSum = int.MaxValue;
            for (int m = 0; m < PointsStreetsHospitals[2]; m++)
            {
                int sum = Dijkstra(hospitals[m] - 1, PointsStreetsHospitals[0]);
                if (sum < bestSum)
                {
                    bestSum = sum;
                }
            }
            Console.WriteLine(bestSum);
        }

        private static int Dijkstra(int start, int n)
        {
            // HashSet<int> visited = new HashSet<int>();
            bool[] visited = new bool[n];
            int[] distances = Enumerable.Repeat(int.MaxValue, n).ToArray();
            distances[start] = 0;

            var queue = new SortedSet<Vertex>();

            queue.Add(new Vertex(start, 0));

            while (queue.Count > 0)
            {
                var current = queue.Min;
                queue.Remove(current);
                // visited.Add(current.Name);
                visited[current.Name] = true;

                foreach (var next in vertices[current.Name])
                {
                    if (distances[next.Name] > distances[current.Name] + next.Weight)
                    {
                        distances[next.Name] = distances[current.Name] + next.Weight;
                        queue.Add(new Vertex(next.Name, distances[next.Name]));
                    }
                }

                while (queue.Count > 0 &&
                  visited[queue.Min.Name]) // visited.Contains(queue.Min.Name)
                {
                    queue.Remove(queue.Min);
                }
            }

            int sum = 0;

            for (int i = 0; i < hospitals.Length; i++)
            {
                distances[hospitals[i] - 1] = 0;
            }

            for (int k = 0; k < n; k++)
            {
                sum += distances[k];
            }
            return sum;
        }

        private static void ReadInput(int v1, int v2)
        {
            vertices = new List<Vertex>[v1];

            for (int i = 0; i < v2; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = edge[0] - 1;
                var to = edge[1] - 1;
                var w = edge[2];

                AddEdge(from, to, w);
                AddEdge(to, from, w);
            }
        }

        private static void AddEdge(int from, int to, int weight)
        {
            if (vertices[from] == null)
            {
                vertices[from] = new List<Vertex>();
            }
            vertices[from].Add(new Vertex(to, weight));
        }
    }

    public class Vertex : IComparable<Vertex>
    {
        public Vertex(int name, int weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public int Name { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Vertex other)
        {
            if (this.Weight.CompareTo(other.Weight) == 0)
            {
                return this.Name.CompareTo(other.Name);
            }
            return this.Weight.CompareTo(other.Weight);
        }
    }
}