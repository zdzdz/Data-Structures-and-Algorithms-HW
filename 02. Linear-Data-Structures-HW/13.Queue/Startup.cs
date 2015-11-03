namespace Queue
{
    using System;
    using System.Collections.Generic;

    public class Startup
    {
        public static void Main()
        {
            var queue = new MyQueue<int>(1);

            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(4);

            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }
    }
}
