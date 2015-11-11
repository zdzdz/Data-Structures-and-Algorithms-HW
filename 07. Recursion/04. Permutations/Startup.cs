using System;

namespace Permutations
{
    public class Startup
    {
        public static void Main()
        {
            Console.Write("Please enter a number: ");
            int input = int.Parse(Console.ReadLine());
            var numbers = new int[input];
            for (int i = 0; i < input; i++)
            {
                numbers[i] = i + 1;
            }

            Perm(numbers, 0);
        }

        private static void Perm<T>(T[] arr, int k)
        {
            if (k >= arr.Length)
            {
                Console.WriteLine("{" + string.Join(", ", arr) + "}");
            }
            else
            {
                Perm(arr, k + 1);
                for (int i = k + 1; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    Perm(arr, k + 1);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void Swap<T>(ref T param1, ref T param2)
        {
            var temp = param1;
            param1 = param2;
            param2 = temp;
        }
    }
}
