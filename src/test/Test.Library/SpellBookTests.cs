using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class ShieldTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IOffensiveItem spellBook = new SpellBook();
            Assert.Pass();
        }
    }
}