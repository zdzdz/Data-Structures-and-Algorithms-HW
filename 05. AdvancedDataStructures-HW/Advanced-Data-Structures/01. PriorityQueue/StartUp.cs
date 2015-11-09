//// Implement a class PriorityQueue<T> based on the data structure "binary heap".

namespace PriorityQueue
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            PriorityQueue<Person> people = new PriorityQueue<Person>();
            people.Enquene(new Person("Samuel", 25));
            people.Enquene(new Person("Sancho", 27));
            people.Enquene(new Person("Grigor", 30));
            people.Enquene(new Person("Asya", 24));
            people.Enquene(new Person("Gergana", 35));
            people.Enquene(new Person("Maria", 22));
            people.Enquene(new Person("Pesho", int.MinValue));

            Console.WriteLine("The root: {0}", people.Root);

            while (people.Count > 0)
            {
                Console.WriteLine(people.Dequene());
            }
        }
    }
}