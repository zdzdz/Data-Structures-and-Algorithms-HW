namespace HashTable
{
    using System;

    public class PrintingHashTable
    {
        public static void Print<K, T>(HashTable<K, T> hashTable)
        {
            foreach (var item in hashTable)
            {
                Console.WriteLine("{0} --> {1}", item.Key, item.Value);
            }

            Console.WriteLine(new string('-', 50));
        }
    }
}
