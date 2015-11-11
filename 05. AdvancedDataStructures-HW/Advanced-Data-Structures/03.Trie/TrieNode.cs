namespace Trie
{
    using System;
    using System.Collections.Concurrent;

    public class TrieNode : IComparable<TrieNode>
    {
        private char character;
        private TrieNode parent = null;
        private ConcurrentDictionary<char, TrieNode> children = null;
        private int wordCount;

        public TrieNode(TrieNode parent, char c)
        {
            this.character = c;
            this.wordCount = 0;
            this.parent = parent;
            this.children = new ConcurrentDictionary<char, TrieNode>();
        }

        public void AddWord(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (char.IsLetter(key))
                {
                    if (!this.children.ContainsKey(key))
                    {
                        this.children.TryAdd(key, new TrieNode(this, key));
                    }

                    this.children[key].AddWord(word, index + 1);
                }
                else
                {
                    this.AddWord(word, index + 1);
                }
            }
            else
            {
                if (this.parent != null)
                {
                    lock (this)
                    {
                        this.wordCount++;
                    }
                }
            }
        }

        public int GetCount(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (!this.children.ContainsKey(key))
                {
                    return -1;
                }

                return this.children[key].GetCount(word, index + 1);
            }
            else
            {
                return this.wordCount;
            }
        }

        public void GetTopCounts(TrieNode most_counted, ref int distinct_word_count, ref int total_word_count)
        {
            if (this.wordCount > 0)
            {
                distinct_word_count++;
                total_word_count += this.wordCount;
            }

            foreach (char key in this.children.Keys)
            {
                this.children[key].GetTopCounts(most_counted, ref distinct_word_count, ref total_word_count);
            }
        }

        public override string ToString()
        {
            if (this.parent == null)
            {
                return string.Empty;
            }
            else
            {
                return this.parent.ToString() + this.character;
            }
        }

        public int CompareTo(TrieNode other)
        {
            return this.wordCount.CompareTo(other.wordCount);
        }
    }
}
