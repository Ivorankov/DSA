namespace Problem_01.SortedDictionary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal class EntryPoint
    {
        static void Main()
        {
            var coursesWithStudents = ReadTxtFileAndBuildCollection();

            foreach (var set in coursesWithStudents)
            {
                Console.WriteLine(set.Key);
                var students = set.Value;
                var sortedStudents = students.OrderBy(x => x.LastName).OrderBy(x => x.FrstName).ToList();
                sortedStudents.ForEach(x => Console.WriteLine(x.ToString()));
            }
        }

        private static SortedDictionary<string, List<Student>> ReadTxtFileAndBuildCollection()
        {
            var result = new SortedDictionary<string, List<Student>>();
            using (StreamReader reader = new StreamReader("../../students.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var args = line.Split('|');
                    var courseName = args[2].Trim();
                    var firstName = args[0].Trim();
                    var lastName = args[1].Trim();
                    var currentStudent = new Student(firstName, lastName);

                    if (result.ContainsKey(courseName))
                    {
                        result[courseName].Add(currentStudent);
                    }
                    else
                    {
                        result.Add(courseName, new List<Student>(){ currentStudent });
                    }

                }
            }

            return result;
        }
    }
}
