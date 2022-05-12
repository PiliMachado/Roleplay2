using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class Helmetests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void GetDefenseValueTest()
        {
            IDefensiveItem helmet = new Helmet();
            int actual = helmet.DefenseValue;
            Assert.AreEqual(18, actual);
        }
    }
}