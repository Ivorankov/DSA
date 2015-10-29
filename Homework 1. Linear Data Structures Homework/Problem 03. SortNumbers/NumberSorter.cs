

namespace Problem_03.SortNumbers
{
    using System;
    using System.Collections.Generic;

   public class NumberSorter
    {
        static void Main()
        {
            var numbers = new List<int>();
            Console.WriteLine("Please, enter some number :)");
            while (true)
            {
                var userInput = Console.ReadLine();
                if (userInput == "")
                {
                    break;
                }

                int number = 0;
                var isValidNumber = int.TryParse(userInput, out number);

                if (isValidNumber)
                {
                    numbers.Add(number);
                    Console.WriteLine("Thank you, may I have another");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }

            Console.WriteLine("Sorting....");
            numbers.Sort();
            Console.WriteLine("Your numbers are sorted. Here they are: ");
            numbers.ForEach(x => Console.Write(x + " "));

            Console.ReadLine();
        }
    }
}
