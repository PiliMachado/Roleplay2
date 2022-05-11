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
        public void GetAttackValueTest() // Testeamos que el attackvalue sea el valor fijo que tiene la clase FireBall.
        {
            ISpell fireBall = new FireBall();
            int actual = fireBall.AttackValue;
            Assert.AreEqual(70, actual);
        }

        [Test]
        public void GetDefenseValueTest() // Testeamos que el defensevalue sea el valor fijo que tiene la clase FireBall.
        {
            ISpell fireBall = new FireBall();
            int actual = fireBall.DefenseValue;
            Assert.AreEqual(70, actual);
        }
    }
}