namespace Problem_03.FindWords
{
    using System;
    using System.Collections.Concurrent;

    public class TrieNode : IComparable<TrieNode>
    {
        private char m_char;

        public int word_count;

        private TrieNode parent = null;

        private ConcurrentDictionary<char, TrieNode> children = null;

        public TrieNode(TrieNode parent, char c)
        {
            m_char = c;
            word_count = 0;
            this.parent = parent;
            children = new ConcurrentDictionary<char, TrieNode>();
        }

        public void AddWord(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (char.IsLetter(key))
                {
                    if (!children.ContainsKey(key))
                    {
                        children.TryAdd(key, new TrieNode(this, key));
                    }
                    children[key].AddWord(word, index + 1);
                }
                else
                {

                    AddWord(word, index + 1);
                }
            }
            else
            {
                if (parent != null) 
                {
                    lock (this)
                    {
                        word_count++;
                    }
                }
            }
        }

        public int GetCount(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (!children.ContainsKey(key))
                {
                    return -1;
                }
                return children[key].GetCount(word, index + 1);
            }
            else
            {
                return word_count;
            }
        }

        public override string ToString()
        {
            if (parent == null) return "";
            else return parent.ToString() + m_char;
        }

        public int CompareTo(TrieNode other)
        {
            return this.word_count.CompareTo(other.word_count);
        }
    }
}
