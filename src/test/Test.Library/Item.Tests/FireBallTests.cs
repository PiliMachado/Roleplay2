using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class FireBallTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAttackValueTest()
        {
            ISpell fireBall = new FireBall();
            int actual = fireBall.AttackValue;
            Assert.AreEqual(70, actual);
        }

        [Test]
        public void GetDefenseValueTest()
        {
            ISpell fireBall = new FireBall();
            int actual = fireBall.DefenseValue;
            Assert.AreEqual(70, actual);
        }
    }
}