namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main()
        {
            var maxCapacity = 10;

            var products = new List<List<int>>()
            {
                new List<int>() { 3, 2 },
                new List<int>() { 8, 12 },
                new List<int>() { 4, 5 },
                new List<int>() { 1, 4 },
                new List<int>() { 2, 3 },
                new List<int>() { 8, 13 },
            };

            var currentBestCost = 0;
            var currentWeigth = 0;
            var maxCost = 0;
            var maxWeigth = 0;
            for (int i = 0; i < products.Count; i++)
            {
                currentWeigth = products[i][0];
                currentBestCost = products[i][1];
                for (int j = i + 1; j < products.Count; j++)
                {
                    currentWeigth += products[j][0];
                    if (currentWeigth <= maxCapacity)
                    {
                        currentBestCost += products[j][1];

                        if (maxCost < currentBestCost)
                        {
                            maxCost = currentBestCost;
                            maxWeigth = currentWeigth;
                        }
                    }
                    else
                    {
                        var isValid = currentWeigth - products[j - 1][0] < maxCapacity;
                        if (isValid)
                        {
                            var newSum = currentBestCost + products[j][1] - products[j - 1][1];
                            if (newSum > currentBestCost)
                            {
                                maxCost = newSum;
                                currentBestCost = newSum;
                                currentWeigth = currentWeigth - products[j - 1][0];
                                maxWeigth = currentWeigth;
                            }
                        }
                        else
                        {
                            currentWeigth -= products[j][0];
                        }
                    }

                }
            }

            //A bit messy but it works
            Console.WriteLine("Cost " + maxCost + " Weigth " + maxWeigth);
            Console.ReadKey();
        }
    }
}
