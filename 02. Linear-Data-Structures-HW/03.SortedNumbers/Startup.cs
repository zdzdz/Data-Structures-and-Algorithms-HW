/*Write a program that reads a sequence of integers 
(List<int>) ending with an empty line and sorts 
them in an increasing order*/

namespace SortedNumbers
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            List<int> collection = new List<int>();
            string current;
            while (true)
            {
                Console.WriteLine("Enter current number to input in list and when you are ready, press [enter]:");
                current = Console.ReadLine();
                if (string.IsNullOrEmpty(current.ToString()))
                {
                    break;
                }
                collection.Add(int.Parse(current));
            }


            collection.Sort();
            Console.WriteLine(String.Join(",", collection));
        }
    }
}
