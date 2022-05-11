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
        public void GetAttackValueTest()
        {
            IOffensiveItem axe = new Axe();
            int actual = axe.AttackValue;
            Assert.AreEqual(25, axe.AttackValue);
        }
    }
}