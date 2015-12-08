namespace ConsoleApplication5
{
    using System;

    internal class Program
    {
        private static int employeeCount;
        private static bool[,] matrix = new bool[64,64];
        private static long[] cache = new long[64];

        static void Main()
        {
            employeeCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < employeeCount; i++)
            {
                string line = Console.ReadLine();

                for (int j = 0; j < employeeCount; j++)
                {
                    matrix[i,j] = (line[j] == 'Y');
                }
            }

            long  salaries = 0;
            for (int i = 0; i < employeeCount; i++)
            {
                salaries += FindSalary(i);
            }
            Console.WriteLine(salaries);
        }

        private static long FindSalary(int employee)
        {
            if (cache[employee] > 0)
            {
                return cache[employee];
            }

            long  salary = 0;
            for (int i = 0; i < employeeCount; i++)
            {
                if (matrix[employee,i])
                {
                    salary += FindSalary(i);
                }
            }
            if (salary == 0)
            {
                salary = 1;
            }

            cache[employee] = salary;

            return salary;
        }
    }
}
