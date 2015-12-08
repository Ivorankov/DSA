namespace Medium_edit_distance
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main()
        {
            var x = "developer";
            var y = "enveloped";
            var result = new String('a',x.Length);

            double inserts = 0;
            double deletes = 0;
            double replaces = 0;

            var length = 0;
            if(x.Length > y.Length)
            {
                length = y.Length;
                deletes = x.Length - y.Length;
            }
            else
            {
                length = x.Length;
                inserts = y.Length - x.Length;
            }

            for (int i = 0; i < length; i++)
            {
                if(y[i] != x[i])
                {
                    replaces++;
                }
            }

            while(replaces > 1)
            {
                replaces -= 2;
                inserts++;
                deletes++;
            }

            inserts *= 0.8;
            deletes *= 0.9;

            Console.WriteLine("Replace costs: " + replaces);
            Console.WriteLine("Insert costs: " + inserts);
            Console.WriteLine("Delete cost: " + deletes);
            var totalCost = replaces + inserts + deletes;
            Console.WriteLine("Total coslt : " + totalCost);

            Console.ReadKey();

        }
    }
}
