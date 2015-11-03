// Implement the ADT stack as auto-resizable array.
// Resize the capacity on demand (when no space is available to add / insert a new element).

namespace Stack
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var testStack = new MyStack<int>();

            for (int i = 0; i < 10; i++)
            {
                testStack.Push((i + 1) * 5);
                Console.WriteLine("At position {0}. is inserted {1}", i, testStack.Peek());
            }

            var lastElement = testStack.Pop();
            Console.WriteLine("{0} was removed from the stack", lastElement);

            Console.WriteLine("The number of elemnents in the satck is {0} and last one is {1}", testStack.Count, testStack.Peek());
        }
    }
}