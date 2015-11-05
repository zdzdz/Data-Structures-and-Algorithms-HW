using System.Collections.Generic;

namespace HashTable.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindTests
    {
        [TestMethod]
        public void ShouldReturnTheRightValueWhenTheRequestedKeyIsAvailable()
        {
            var hashtable = new HashTable<int, string>();

            int numberOfAddedElements = 5;
            for (int i = 0; i < numberOfAddedElements; i++)
            {
                hashtable.Add(i, "test" + i);
            }

            var foundValue = hashtable.Find(3);

            Assert.AreEqual("test3", foundValue);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ShouldThrowWhenRequesttedKeyIsNotAvailable()
        {
            var hashtable = new HashTable<int, string>();

            int numberOfAddedElements = 5;
            for (int i = 0; i < numberOfAddedElements; i++)
            {
                hashtable.Add(i, "test" + i);
            }

            var foundValue = hashtable.Find(10);
        }
    }
}