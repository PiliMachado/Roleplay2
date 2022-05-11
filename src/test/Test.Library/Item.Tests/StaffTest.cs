using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class StaffTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAttackValueTest()
        {
            IMageItem staff = new Staff();
            int actual = staff.AttackValue;
            Assert.AreEqual(100, actual);
        }

        [Test]
        public void GetDefenseValueTest()
        {
            IMageItem staff = new Staff();
            int actual = staff.DefenseValue;
            Assert.AreEqual(100, actual);
        }
    }
}