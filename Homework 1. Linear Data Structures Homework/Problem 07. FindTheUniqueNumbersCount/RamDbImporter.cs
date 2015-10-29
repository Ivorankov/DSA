namespace Problem_07.FindTheUniqueNumbersCount
{
    using System;
    using System.Collections.Generic;

   public class RamDbImporter
    {
       private static Random rnd = new Random();

       public static List<int> ImportNumbers(int count = 20000)
       {
           var numbers = new List<int>();
           for (int i = 0; i < count; i++)
           {
               numbers.Add(rnd.Next(0,1001));
           }

           return numbers;
       }
    }
}
