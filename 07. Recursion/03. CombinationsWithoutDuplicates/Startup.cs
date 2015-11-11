namespace CombinationsWithoutDuplicates
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter from how many element you want to choose: ");
            int elements = int.Parse(Console.ReadLine());
            Console.Write("Please enter how many combinations you want: ");
            int size = int.Parse(Console.ReadLine());
            var numbers = new int[size];
            ArrayCombinations(numbers, elements, 0);
        }

        private static void ArrayCombinations(int[] numbers, int elements, int index)
        {
            if (index == numbers.Length)
            {
                Console.Write("(" + string.Join(" ", numbers) + ")");
                Console.Write(", ");
                return;
            }

            for (int i = 1; i <= elements; i++)
            {
                numbers[index] = i;
                if (index == 0)
                {
                    ArrayCombinations(numbers, elements, index + 1);
                }
                else if (numbers[index - 1] < numbers[index])
                {
                    ArrayCombinations(numbers, elements, index + 1);
                }
            }
        }
    }
}
