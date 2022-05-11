using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class SwordTests
    {
        [Test]
        public void GetAttackValueTest()
        {
            IOffensiveItem sword = new Sword();
            int swordvalue = sword.AttackValue;
            Assert.AreEqual(20, sword.AttackValue);
        }
    }
}