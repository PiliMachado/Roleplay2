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
        public void GetAttackValueTest() // Testeamos que el attackvalue sea el valor fijo que tiene la clase Axe.
        {
            IOffensiveItem axe = new Axe();
            int actual = axe.AttackValue;
            Assert.AreEqual(25, axe.AttackValue);
        }
    }
}