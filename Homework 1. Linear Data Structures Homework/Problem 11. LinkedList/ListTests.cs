using System;

namespace Problem_11.LinkedList
{
   public class ListTests
    {
       static void Main()
       {
           var test = new LinkedList<string>();
           test.Add("Alfa");
           test.Add("Beta");
           test.Add("Gama");
           test.Add("Delta");

           test.ListNodes();

           var item = test.Retrieve(2);

           Console.WriteLine("Second item: " + item.Value);

           test.Delete(2);

           test.ListNodes();

           Console.ReadKey();
       }
    }
}
