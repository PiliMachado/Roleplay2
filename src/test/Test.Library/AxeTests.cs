using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class AxeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IOffensiveItem axe = new Axe();
            Assert.Pass();
        }
    }
}