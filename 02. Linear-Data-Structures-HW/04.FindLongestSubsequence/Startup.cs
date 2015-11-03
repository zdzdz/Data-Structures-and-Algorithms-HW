/*Write a method that finds the longest subsequence of equal numbers in given List 
and returns the result as new List<int>.
Write a program to test whether the method works correctly.*/

namespace FindLongestSubsequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine("Enter N integrer numbers separated by space or coma: ");
            List<int> listOfNumbers = Console.ReadLine()
               .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(x => int.Parse(x))
               .ToList();

            List<int> longestSequence = FindTheLogestSequenceOfEqualNumbers(listOfNumbers);

            Console.WriteLine("The logest sequence has {0} elements each of them is {1}", longestSequence.Count, longestSequence.First());
        }

        private static List<int> FindTheLogestSequenceOfEqualNumbers(List<int> listOfNumbers)
        {
            int counter = 1;
            int longestSequence = 1;
            int value = 0;
            for (int i = 1; i < listOfNumbers.Count; i++)
            {
                if (listOfNumbers[i] == listOfNumbers[i - 1])
                {
                    counter++;
                    if (longestSequence < counter)
                    {
                        longestSequence = counter;
                        value = listOfNumbers[i];
                    }
                }
                else
                {
                    counter = 1;
                }
            }

            int[] numberToAdd = Enumerable.Repeat(value, longestSequence).ToArray();

            var result = new List<int>(longestSequence);

            result.AddRange(numberToAdd);

            return result;
        }
    }
}