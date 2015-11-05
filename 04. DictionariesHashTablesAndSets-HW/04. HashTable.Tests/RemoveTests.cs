namespace HashTable.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RemoveTests
    {
        [TestMethod]
        public void ShouldRemoveTheElement()
        {
            var hashtable = new HashTable<int, string>();

            for (int i = 0; i < 5; i++)
            {
                hashtable.Add(i, "test");
                Assert.AreEqual(i + 1, hashtable.Count);
            }

            List<int> keys = (List<int>)hashtable.Keys;
            var keyToRemove = keys[0];

            hashtable.Remove(keys[0]);

            Assert.IsFalse(hashtable.ContainsKey(keyToRemove));
        }

        [TestMethod]
        public void ShouldDoNothingWhenTryToRemoveUnavailableKey()
        {
            var hashtable = new HashTable<int, string>();

            for (int i = 0; i < 5; i++)
            {
                hashtable.Add(i, "test");
                Assert.AreEqual(i + 1, hashtable.Count);
            }

            List<int> keys = (List<int>)hashtable.Keys;
            var numberOfKeys = keys.Count;
            var keyToRemove = keys[0];

            hashtable.Remove(keyToRemove);

            Assert.AreEqual(numberOfKeys, keys.Count);
        }

        [TestMethod]
        public void ShouldDecreaseCounterByOneWhenRemoveingElement()
        {
            var hashtable = new HashTable<int, string>();

            for (int i = 0; i < 5; i++)
            {
                hashtable.Add(i, "test");
                Assert.AreEqual(i + 1, hashtable.Count);
            }

            List<int> keys = (List<int>)hashtable.Keys;
            var numberOfKeys = hashtable.Count;
            var keyToRemove = keys[0];

            hashtable.Remove(keyToRemove);

            Assert.AreEqual(numberOfKeys - 1, hashtable.Count);
        }
    }
}