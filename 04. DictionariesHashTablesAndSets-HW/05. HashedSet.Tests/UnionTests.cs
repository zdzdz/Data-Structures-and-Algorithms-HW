namespace HashedSet.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnionTests
    {
        [TestMethod]
        public void UnionExpectedToWorkProperly()
        {
            var firstSet = new HashedSet<string>();
            for (int i = 1; i <= 10; i++)
            {
                firstSet.Add("test" + i);
            }

            var secondSet = new HashedSet<string>();
            for (int i = 5; i <= 15; i++)
            {
                secondSet.Add("test" + i);
            }

            firstSet.Union(secondSet);

            Assert.AreEqual(15, firstSet.Count);

            for (int i = 1; i <= 15; i++)
            {
                Assert.IsTrue(firstSet.Find("test" + i));
            }
        }
    }
}