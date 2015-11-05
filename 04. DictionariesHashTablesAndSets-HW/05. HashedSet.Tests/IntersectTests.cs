namespace HashedSet.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IntersectTests
    {
        [TestMethod]
        public void IntersectExpectedToWorkProperly()
        {
            var firstSet = new HashedSet<string>();
            for (int i = 1; i <= 10; i++)
            {
                firstSet.Add("test" + i);
            }

            var secondSet = new HashedSet<string>();
            for (int i = 6; i <= 15; i++)
            {
                secondSet.Add("test" + i);
            }

            firstSet.Intersect(secondSet);

            Assert.AreEqual(5, firstSet.Count);

            for (int i = 6; i <= 10; i++)
            {
                Assert.IsTrue(firstSet.Find("test" + i));
            }
        }
    }
}