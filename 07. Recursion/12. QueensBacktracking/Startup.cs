namespace QueensBacktracking
{
    using System;
    using System.Diagnostics;

    public class Startup
    {
        public static void Main()
        {
            int boardSize = 8;
            var board = new QueenBoard(boardSize);
            Console.WriteLine("Number of solutions: {0}", board.FindQueensSolutions());
            var counter = 1000;
            Stopwatch watch = new Stopwatch();

            watch.Start();
            for (int i = 0; i < counter; i++)
            {
                board.FindQueensSolutions();
            }

            Console.WriteLine("Time elapsed for 1000 times of finding the solutions: {0}", watch.Elapsed);
        }
    }
}
