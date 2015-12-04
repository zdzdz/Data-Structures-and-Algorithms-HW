namespace Salaries
{
    using System;

    public class Startup
    {
        static int numberOfEmployees;
        static bool[,] matrix;
        static long[] memo;

        public static void Main()
        {
            numberOfEmployees = int.Parse(Console.ReadLine());
            matrix = new bool[numberOfEmployees, numberOfEmployees];
            memo = new long[numberOfEmployees];

            for (int i = 0; i < numberOfEmployees; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < numberOfEmployees; j++)
                {
                    matrix[i, j] = (line[j] == 'Y');
                }
            }

            long sumOfSalaries = 0;

            for (int i = 0; i < numberOfEmployees; i++)
            {
                sumOfSalaries += FindSalary(i);
            }
            Console.WriteLine(sumOfSalaries);
        }

        private static long FindSalary(int employee)
        {
            if (memo[employee] > 0)
            {
                return memo[employee];
            }

            long salary = 0;
            for (int i = 0; i < numberOfEmployees; i++)
            {
                if (matrix[employee, i])
                {
                    salary += FindSalary(i);
                }
            }
            if (salary == 0)
            {
                salary = 1;
            }
            memo[employee] = salary;
            return salary;
        }
    }
}