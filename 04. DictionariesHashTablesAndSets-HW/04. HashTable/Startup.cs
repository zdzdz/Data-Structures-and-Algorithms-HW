namespace HashTable
{
    using System;

    public class Startup
    {
        public static void Main()
        { 
            var testHashtable = new HashTable<int, string>();
            testHashtable.Add(1, "hello");
            testHashtable.Add(2, "Bye");
            testHashtable.Add(3, "cat");
            testHashtable.Add(4, "dog");
            testHashtable.Add(5, "monkey");
            testHashtable.Add(6, "Luffy");
            testHashtable.Add(8, "eight");
            PrintingHashTable.Print(testHashtable);

            Console.WriteLine(testHashtable.ContainsKey(8));
            Console.WriteLine(new string('-', 50));

            Console.WriteLine(testHashtable.Find(6));
            Console.WriteLine(new string('-', 50));
            
            testHashtable.Remove(8);
            PrintingHashTable.Print(testHashtable);

            testHashtable.Clear();
            PrintingHashTable.Print(testHashtable);
        }
    }
}
