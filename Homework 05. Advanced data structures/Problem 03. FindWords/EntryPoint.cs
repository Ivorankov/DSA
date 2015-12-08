using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_03.FindWords
{
    class EntryPoint
    {
        private static TrieNode root = new TrieNode(null, '?');

        private static string hugeText = "Large texts do not fit in Student a System text so the text" +
                                         " is gonna be text smaller then student expected text but a text is still text or student";

        static void Main()
        {
            var trie = FillTrie();

            var textWordCount = trie.GetCount("text");
            var aLetterCount = trie.GetCount("a");
            var isWordCount = trie.GetCount("is");

            Console.WriteLine("text - " + textWordCount);
            Console.WriteLine("a - " + aLetterCount);
            Console.WriteLine("is - " + isWordCount);

        }

        private static TrieNode FillTrie()
        {
            var result = new TrieNode(root, 'c');
            var words = hugeText.Split(new char[] { ' ', '.', ',', '!', '?' }).ToList();
            foreach (var word in words)
            {
                result.AddWord(word);
            }

            return result;
        }
    }
}
