namespace Bots.Helpers
{
    using System.Collections.Generic;

    internal class Searcher
    {
        public static string Search(Command command, List<Person> people)
        {
            if (command.Town != null)
            {
                var test = FindNameWithTown(command.NameToSeachFor, command.Town, people);
                if (test != null)
                {
                    return test.ToString();
                }
                else
                {
                    return "Could not find the person";
                }

            }
            else
            {
                var test = FindName(command.NameToSeachFor, people);
                if (test != null)
                {
                    return test.ToString();
                }
                else
                {
                    return "Could not find the person";
                }

            }          
        }

        public static Person FindName(string name, List<Person> people)
        {

            foreach (var person in people)
            {
                if (person.Name.Contains(name))
                {
                    return person;
                }
            }

            return null;
        }

        public static Person FindNameWithTown(string name, string town, List<Person> people)
        {
            foreach (var person in people)
            {
                if (person.Name.Contains(name) && person.Town.Contains(town))
                {
                    return person;
                }
            }

            return null;
        }
    }
}
