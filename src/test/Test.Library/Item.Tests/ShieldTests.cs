using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class ShieldTests
    {
        [Test]
        public void GetDefensiveValueTest()
        {
            IDefensiveItem shield = new Shield();
            int shieldvalue = shield.DefenseValue;
            Assert.AreEqual(14, shield.DefenseValue);
        }
    }
}