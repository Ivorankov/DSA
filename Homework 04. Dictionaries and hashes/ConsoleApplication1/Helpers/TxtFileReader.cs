namespace Bots.Helpers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal static class TxtFileReader
    {
        public static List<Person> ExtractPeople(string path)
        {
            var result = new List<Person>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var currentEntry = reader.ReadLine();
                    var test = currentEntry.Split('|').ToList();
                    if (test.Count == 3)
                    {
                        result.Add(new Person(test[0].Trim(), test[1].Trim(), test[2].Trim()));
                    }

                }
            }

            return result;
        }

        public static List<Command> ExtractCommands(string path)
        {
            var result = new List<Command>();
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    var currentEntry = reader.ReadLine();
                    var test = currentEntry.Contains('|');

                    if (!test && !string.IsNullOrEmpty(currentEntry))
                    {
                        var command = Parser.ParseCommand(currentEntry);
                        result.Add(command);
                    }
                }
            }

            return result;
        }
    }
}
