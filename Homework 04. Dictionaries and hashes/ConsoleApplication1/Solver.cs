using System.Collections.Generic;
using System.Linq;

namespace Bots.Helpers
{
   internal static class Solver
    {
       public static Dictionary<int,int> CountUniqueValues(List<int> numbers) // Problem 1
       {
           var sequences = new Dictionary<int, int>();

           for (int i = 0; i < numbers.Count; i++)
           {
               if (sequences.ContainsKey(numbers[i]))
               {
                   sequences[numbers[i]]++;
               }
               else
               {
                   sequences[numbers[i]] = 1;
               }
           }

           return sequences;
       }

       public static Dictionary<string,int> ExtractItemsWithOddCount(List<string> languages)  //Problem 2
       {
           var sequences = new Dictionary<string, int>();

           for (int i = 0; i < languages.Count; i++)
           {
               if (sequences.ContainsKey(languages[i]))
               {
                   sequences[languages[i]]++;
               }
               else
               {
                   sequences[languages[i]] = 1;
               }
           }

           var res = new Dictionary<string, int>();

           foreach (var set in sequences)
           {
               if (set.Value%2 != 0)
               {
                   res[set.Key] = set.Value;
               }
           }

           return res;
       }

       public static Dictionary<string, int> CountUniqueWordsFromText(string text) // Problem 3
       {
           var languages = Parser.ParseWordsFromText(text);

           var sequences = new Dictionary<string, int>();

           for (int i = 0; i < languages.Count; i++)
           {
               if (sequences.ContainsKey(languages[i]))
               {
                   sequences[languages[i]]++;
               }
               else
               {
                   sequences[languages[i]] = 1;
               }

           }
           var test = sequences.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

           return test;
       }
    }
}
