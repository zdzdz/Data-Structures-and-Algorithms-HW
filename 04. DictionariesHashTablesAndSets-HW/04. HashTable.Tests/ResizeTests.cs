namespace HashTable.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ResizeTests
    {
        [TestMethod]
        public void ShouldResizeHashWhenElementsNumberReachesCertainPoint()
        {
            var initialCapacity = 8;
            var hashtable = new HashTable<int, string>(initialCapacity);
            var pointToDouble = 8 * 0.75;

            for (int i = 0; i < 2 * pointToDouble; i++)
            {
                hashtable.Add(i, "test");

                if (i <= pointToDouble)
                {
                    Assert.AreEqual(initialCapacity, hashtable.Capacity);
                }
                else
                {
                    Assert.AreEqual(initialCapacity * 2, hashtable.Capacity);
                }
            }
        }
    }
}
