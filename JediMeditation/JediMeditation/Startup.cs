namespace JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Startup
    {
        public static void Main()
        {
            var numberOfJedis = int.Parse(Console.ReadLine());
            var jedis = Console.ReadLine();


            var parsedJedis = Jedi.ParseChars(jedis);
            MeditationOrder.AddMeditators(parsedJedis);
            Console.WriteLine(MeditationOrder.OrderMeditators().Trim());
        }

        public static class Jedi
        {
            public static string[] ParseChars(string input)
            {
                string[] result;
                result = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                return result;
            }
        }

        public static class MeditationOrder
        {
            public static Queue<string> masters = new Queue<string>();
            public static Queue<string> knights = new Queue<string>();
            public static Queue<string> padawans = new Queue<string>();

            public static void AddMeditators(string[] members)
            {

                foreach (var member in members)
                {
                    switch (member[0])
                    {
                        case 'm':
                            masters.Enqueue(member);
                            break;
                        case 'k':
                            knights.Enqueue(member);
                            break;
                        case 'p':
                            padawans.Enqueue(member);
                            break;
                    }
                }
            }

            public static string OrderMeditators()
            {
                StringBuilder result = new StringBuilder();

                while (masters.Count > 0)
                {
                    result.Append(masters.Dequeue());
                    result.Append(' ');
                }
                while (knights.Count > 0)
                {
                    result.Append(knights.Dequeue());
                    result.Append(' ');
                }
                while (padawans.Count > 0)
                {
                    result.Append(padawans.Dequeue());
                    result.Append(' ');
                }

                return result.ToString();
            }
        }
    }
}
