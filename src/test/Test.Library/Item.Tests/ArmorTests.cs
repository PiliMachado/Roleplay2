using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class ArmorTests
    {
        [Test]
        public void GetDefensiveValueTest()
        {
            IDefensiveItem armor = new Armor();
            
            Assert.AreEqual(25, armor.DefenseValue);
        }
    }
}