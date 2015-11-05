namespace HashedSet.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindTests
    {
        [TestMethod]
        public void ShouldReturnTrueWhenTryingToFindAvailableElement()
        {
            var hashedSet = new HashedSet<string>();

            for (int i = 0; i < 10; i++)
            {
                hashedSet.Add("test" + i);
            }

            for (int i = 0; i < 10; i++)
            {
                var expectedTrue = hashedSet.Find("test" + i);

                Assert.IsTrue(expectedTrue);
            }
        }

        [TestMethod]
        public void ShouldReturnFalseWhenTryingToFindUnavailableElement()
        {
            var hashedSet = new HashedSet<string>();

            for (int i = 0; i < 10; i++)
            {
                hashedSet.Add("test" + i);
            }

            for (int i = 0; i < 10; i++)
            {
                var expectedFalse = hashedSet.Find("false" + i);

                Assert.IsFalse(expectedFalse);
            }
        }
    }
}