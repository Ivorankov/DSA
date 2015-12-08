using System;

namespace Bots
{
    using System.Collections.Generic;
    using System.Speech.Synthesis;
    using Helpers;

    public static class GLaDOS
    {
        private const string WelcomeMsg = "Hello, welcome to homework 4: Dictionaries, Hash tables and sets." +
                                          " My name is GLaDOS and I will be solving this homework today";

        private const string GoodbyeMsg = "That was it for me, I'll be portaling out of here now Goodbye!";

        public static void SolveHomework()
        {
            Speak(WelcomeMsg);

            Speak("Solving task 1");
            var numbers = new List<int>() { 1, 2, 3, 3, 3, 4, 4, 4, 5, 1, 8, -5, -5 };
            numbers.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            ProcessIntIntSet(Solver.CountUniqueValues(numbers));

            Speak("Solving task 2");
            var languages = new List<string>() { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            languages.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            ProcessStringIntSet(Solver.ExtractItemsWithOddCount(languages));

            Speak("Solving task 3");
            var text = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text? Is the rly the text????";
            Console.WriteLine(text);
            ProcessStringIntSet(Solver.CountUniqueWordsFromText(text));

            Speak("Solving task 6");
            var pathToTxtFile = "../../phones.txt";
            ProcessSearchResults(pathToTxtFile);
            Speak(GoodbyeMsg);
        }

        private static void Speak(string msg)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;  // 0...100
            synthesizer.Rate = 1;     // -10...10
            synthesizer.SelectVoiceByHints(VoiceGender.Female);
            synthesizer.Speak(msg);
            synthesizer.Dispose();
        }

        private static void ProcessStringIntSet(Dictionary<string, int> results)
        {
            foreach (var set in results)
            {
                Speak(set.Key + ": " + set.Value + " times");
            }
        }

        private static void ProcessIntIntSet(IDictionary<int,int> results)
        {
            foreach (var set in results)
            {
                Speak(set.Key + ": " + set.Value + " times");
            }
        }

        private static void ProcessSearchResults(string pathToTxtFile)
        {
            var index = pathToTxtFile.LastIndexOf('/');
            var nameOfFile = pathToTxtFile.Substring(index, pathToTxtFile.Length - (pathToTxtFile.Length - index - 1));
            Speak("Reading phones.txt and extracting people");
            var people = TxtFileReader.ExtractPeople(pathToTxtFile);

            Speak("Now I'm extracting the commands from the file");
            var commands = TxtFileReader.ExtractCommands(pathToTxtFile);

            foreach (var command in commands)
            {
                string townSearchParam = string.Empty;
                if (command.Town != null)
                {
                    townSearchParam += ", in town: " + command.Town;
                }
  
                Speak("Searching for : " + command.NameToSeachFor + townSearchParam);
                Speak(Searcher.Search(command, people));
            }
        }
    }
}
