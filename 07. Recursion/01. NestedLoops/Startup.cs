using System;

namespace NestedLoops
{
    public class Startup
    {
        public static void Main()
        {
            while (1 == 1)
            {
                Console.Write("Please enter the size of the array (Type 'Exit' to stop): ");
                string input = Console.ReadLine();
                int n;
                var isNumber = int.TryParse(input, out n);

                if (String.IsNullOrEmpty(input) || input.ToLower() == "quit" || input.ToLower() == "exit" || !isNumber)
                {
                    break;
                }
                Console.WriteLine(new string('=', 50));
                int[] numbers = new int[int.Parse(input)];
                SimulateNestedLoops(numbers, 0);
            }
        }

        public static void SimulateNestedLoops(int[] numbers, int index)
        {
            if (index == numbers.Length)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }

            for (int j = 1; j <= numbers.Length; j++)
            {
                numbers[index] = j;
                SimulateNestedLoops(numbers, index + 1);
            }
        }
    }
}
