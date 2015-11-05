namespace HashedSet.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ClearTests
    {
        [TestMethod]
        public void ShouldEmtyTheSet()
        {
            var hashedSet = new HashedSet<string>();

            for (int i = 0; i < 10; i++)
            {
                hashedSet.Add("test" + i);
            }

            hashedSet.Clear();

            Assert.AreEqual(0, hashedSet.Count);
        }
    }
}