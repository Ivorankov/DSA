namespace Problem_02.NumbersInStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StackTests
    {
        static void Main()
        {
            var numbers = new Stack<string>();

            Console.WriteLine("Please enter some numbers in one line separated by space: ");
            var userInput = Console.ReadLine().Split(' ').ToArray();

            for (int i = 0; i < userInput.Length; i++)
            {
                numbers.Push(userInput[i]);
            }

            Console.WriteLine("Here are your numbers in reverse: ");

            for (int i = 0; i < userInput.Length; i++)
            {
                Console.Write(numbers.Pop() + " ");
            }

            Console.ReadKey();
        }
    }
}
