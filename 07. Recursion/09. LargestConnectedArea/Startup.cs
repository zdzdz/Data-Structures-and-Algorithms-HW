namespace LargestConnectedArea
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            char[,] matrix = new char[,]
            {
                { '*', 'x', '*', 'x', '*', '*' },
                { 'x', 'x', '*', 'x', 'x', '*' },
                { '*', 'x', 'x', 'x', '*', 'x' },
                { '*', 'x', '*', 'x', '*', 'x' },
                { '*', 'x', '*', 'x', '*', '*' },
                { '*', 'x', '*', 'x', '*', '*' },
            };

            var lab = new Labirinth(matrix);
            lab.FindLargestConnectedArea();
        }
    }
}
