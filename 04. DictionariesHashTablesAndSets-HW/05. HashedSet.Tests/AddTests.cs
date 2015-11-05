namespace HashedSet.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AddTests
    {
        [TestMethod]
        public void ShouldBeAbleToAddNewElements()
        {
            var hashedSet = new HashedSet<string>();

            for (int i = 0; i < 10; i++)
            {
                hashedSet.Add("test" + i);
                Assert.AreEqual(i + 1, hashedSet.Count);
            }
        }
    }
}