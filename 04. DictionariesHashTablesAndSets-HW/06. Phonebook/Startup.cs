namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Startup
    {
        public static void Main()
        {
            var phonebook = new PhoneBook();

            var info = new string[]
            {
                "Samantha Fox            | Plovdiv  | 0888 12 34 56",
                "Janko Milev             | Varna    | 052 23 45 67",
                "Daniela Ivanova Petrova | Karnobat | 0899 999 888",
                "Sam Sonite              | Sofia    | 02 946 946 946",
                "John Smith              | Varna   | 02 888 946 946",
            };
            
            info.ForEach(x =>
            {
                var groomedArray = x.Split('|').Select(y => y.Trim()).ToArray();

                phonebook.Add(new PersonInfo()
                {
                    Name = groomedArray[0],
                    City = groomedArray[1],
                    PhoneNumber = groomedArray[2]
                });
            });

            var queries = new string[][]
            {
                new string[] { "Samantha" },
                new string[] { "Sam Sonite" },
                new string[] { "John Smith", "Varna" }
            };

            queries.ForEach(x =>
            {
                if (x.Length == 1)
                {
                    phonebook.Find(x[0]).StringJoin().Print();
                }
                else
                {
                    phonebook.Find(x[0], x[1]).StringJoin().Print();
                }
            });
        }
    }

    class Test
    {
        public override int GetHashCode()
        {
            return 5;
        }

        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj);
        }
    }
}
