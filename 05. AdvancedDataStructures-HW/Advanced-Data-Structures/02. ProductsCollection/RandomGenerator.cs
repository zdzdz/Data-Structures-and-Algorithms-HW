namespace ProductsCollection
{
    using System;

    public static class RandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static readonly Random Random = new Random();

        public static decimal RandomDecimalBetween(double minValue, double maxValue)
        {
            var next = Random.NextDouble();

            return (decimal)(minValue + (next * (maxValue - minValue)));
        }

        public static int GetRandomNumber(int min, int max)
        {
            return Random.Next(min, max + 1);
        }

        public static string GetRandomString(int length)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = Letters[GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(result);
        }

        public static string GetRandomStringWithRandomLength(int min, int max)
        {
            return GetRandomString(GetRandomNumber(min, max));
        }
    }
}
