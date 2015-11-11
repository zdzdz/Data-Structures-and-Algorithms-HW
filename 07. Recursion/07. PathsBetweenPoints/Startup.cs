namespace PathsBetweenPoints
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            char[,] matrix = new char[,]
            {
                { '*', '*', '*', '*', '*', '*' },
                { '*', 'x', 'x', 'x', 'x', '*' },
                { '*', '*', '*', '*', 'x', '*' },
                { '*', 'x', 'x', '*', 'x', '*' },
                { '*', 'x', 'x', '*', 'x', '*' },
                { '*', 'x', 'x', '*', '*', '*' },
            };

            while (true)
            {
                var lab = new Labirinth(matrix);
                int startRow;
                Console.Write("Start row: ");
                startRow = int.Parse(Console.ReadLine());
                int startCol;
                Console.Write("Start col: ");
                startCol = int.Parse(Console.ReadLine());
                int endRow;
                Console.Write("End row: ");
                endRow = int.Parse(Console.ReadLine());
                int endCol;
                Console.Write("End col: ");
                endCol = int.Parse(Console.ReadLine());
                Console.WriteLine(new string('-', 20));

                lab.FindPaths(startRow, startCol, endRow, endCol, 'S');
                Console.WriteLine(new string('-', 20));
            }
        }
    }
}
