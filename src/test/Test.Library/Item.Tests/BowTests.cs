using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class BowTests
    {
        [Test]
        public void GetAttackValueTest() // Testeamos que el attackvalue sea el valor fijo que tiene la clase Axe.
        {
            IOffensiveItem bow = new Bow();

            Assert.AreEqual(15, bow.AttackValue);
        }
    }
}