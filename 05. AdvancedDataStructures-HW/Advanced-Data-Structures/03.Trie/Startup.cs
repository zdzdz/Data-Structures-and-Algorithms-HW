/*Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file).
    Print how many times each word occurs in the text.
    Hint: you may find a C# trie in Internet.
*/

namespace Trie
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            /*
            Trie implementation of trie, used in this problem was taken from http://stackoverflow.com/questions/12190326/parsing-one-terabyte-of-text-and-efficiently-counting-the-number-of-occurrences with only minor modifications.
            */

            Console.WriteLine("Processing text file...");
            DateTime startAt = DateTime.Now;
            TrieNode root = new TrieNode(null, '?');

            var path = "../../1000words.txt";
            DataReader newReader = new DataReader(path, ref root);

            newReader.ThreadRun();

            int distinctWordCount = 0;
            int totalWordCount = 0;
            root.GetTopCounts(root, ref distinctWordCount, ref totalWordCount);

            string[] words = new string[] { "Lorem", "lorem", "dolor", "sit", "amet", "consectetur", "adipiscing", "elit", "line", "a" };

            // The loop simulates 10000 word searches in the trie
            for (int i = 0; i < 1000; i++)
            {
                foreach (var word in words)
                {
                    Console.WriteLine("Word: {0}, count {1}", word, root.GetCount(word) > -1 ? root.GetCount(word) : 0);
                }

                Console.WriteLine();
            }

            Console.WriteLine("Number of distinct words in the set: {0}", distinctWordCount);

            DateTime stopAt = DateTime.Now;
            Console.WriteLine("Input data processed in {0} secs", new TimeSpan(stopAt.Ticks - startAt.Ticks).TotalSeconds);
        }
    }
}
