﻿/*Write a program that reads from the console a sequence of positive integer numbers.
    The sequence ends when empty line is entered.
    Calculate and print the sum and average of the elements of the sequence.
    Keep the sequence in List<int>*/

namespace SaveSumInList
{
    using System;
    using System.Collections.Generic;
    

    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int>();
            var sum = 0;

            while (true)
            {
                var input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    numbers.Add(int.Parse(input)); // I don't really need that list to solve the problem...
                    sum += int.Parse(input);
                }
                else
                {
                    Console.WriteLine(sum);
                    break;
                }
            }
        }
    }
}