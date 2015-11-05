namespace HashTable.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ContainsKeyTests
    {
        [TestMethod]
        public void ShouldReturnAppropriateResults()
        {
            var hashtable = new HashTable<int, string>();

            int numberOfAddedElements = 5;
            for (int i = 0; i < numberOfAddedElements; i++)
            {
                hashtable.Add(i, "test" + i);
            }

            var expectedTrue = hashtable.ContainsKey(3);
            var expectedFalse = hashtable.ContainsKey(-1);

            Assert.IsTrue(expectedTrue);
            Assert.IsFalse(expectedFalse);
        }

        [TestMethod]
        public void ShouldAlwaysReturnFalseWhenTableIsEmpty()
        {
            var hashtable = new HashTable<int, string>();

            Assert.IsFalse(hashtable.ContainsKey(-1));
            Assert.IsFalse(hashtable.ContainsKey(0));
            Assert.IsFalse(hashtable.ContainsKey(1));
        }
    }
}