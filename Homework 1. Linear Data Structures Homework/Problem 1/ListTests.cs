namespace Problem_1
{
    using System.Collections.Generic;
    using System;
    using System.Linq;


   public class ListTests
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

            Console.WriteLine("Average of the numbers is: " + numbers.Average());

            Console.WriteLine("The sum of the numbers is: " + numbers.Sum());

            Console.ReadKey();
        }
    }
}
