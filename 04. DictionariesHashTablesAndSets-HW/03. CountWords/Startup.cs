using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CountWords
{
    public class Startup
    {
        public static void Main()
        {
            using (StreamReader reader = new StreamReader("../../input.txt"))
            {
                var text = reader.ReadToEnd();
                var regex =new Regex(@"\w+", RegexOptions.Multiline);
                var words = regex.Matches(text);
                var wordsOccurences = new SortedDictionary<string, int>();

                foreach (var word in words)
                {
                    var wordToLower = word.ToString().ToLower();
                    if (wordsOccurences.ContainsKey(wordToLower))
                    {
                        wordsOccurences[wordToLower]++;
                    }
                    else
                    {
                        wordsOccurences[wordToLower] = 1;
                    }
                }

                var orderedWordsByOccurences = wordsOccurences
                    .OrderBy(w => w.Value);

                foreach (var word in orderedWordsByOccurences)
                {
                    Console.WriteLine("{0} --> {1} times", word.Key, word.Value);
                }
            }
        }
    }
}
