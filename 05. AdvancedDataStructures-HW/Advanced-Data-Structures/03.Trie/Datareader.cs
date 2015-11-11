namespace Trie
{
    using System.IO;

    public class DataReader
    {
        private const int LoopCount = 1;
        private TrieNode trie;
        private string path;

        public DataReader(string path, ref TrieNode root)
        {
            this.trie = root;
            this.path = path;
        }

        public void ThreadRun()
        {
            for (int i = 0; i < LoopCount; i++)
            {
                using (FileStream fstream = new FileStream(this.path, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sreader = new StreamReader(fstream))
                    {
                        string line;
                        while ((line = sreader.ReadLine()) != null)
                        {
                            string[] chunks = line.Split(null);
                            foreach (string chunk in chunks)
                            {
                                this.trie.AddWord(chunk.Trim());
                            }
                        }
                    }
                }
            }
        }
    }
}
