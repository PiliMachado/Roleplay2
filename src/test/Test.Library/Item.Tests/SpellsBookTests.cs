using NUnit.Framework;
using RoleplayGame;

namespace Test.Library
{
    public class SpellsBookTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SingleSpellGetAttackValueTest()
        {
            SpellsBook spellsBook = new SpellsBook();
            ISpell fireBall = new FireBall();
            spellsBook.Spells = new ISpell[]{ fireBall };
            int actual = spellsBook.AttackValue;
            Assert.AreEqual(fireBall.AttackValue, actual);
        }

        [Test]
        public void MultipleSpellsGetAttackValueTest()
        {
            SpellsBook spellsBook = new SpellsBook();
            ISpell fireBall = new FireBall();
            ISpell fireBall2 = new FireBall();
            ISpell fireBall3 = new FireBall();
            spellsBook.Spells = new ISpell[]{ fireBall, fireBall2, fireBall3 };
            int actual = spellsBook.AttackValue;
            Assert.AreEqual(fireBall.AttackValue + fireBall2.AttackValue + fireBall3.AttackValue, actual);
        }

        [Test]
        public void SingleSpellGetDefenseValueTest()
        {
            SpellsBook spellsBook = new SpellsBook();
            ISpell fireBall = new FireBall();
            spellsBook.Spells = new ISpell[]{ fireBall };
            int actual = spellsBook.DefenseValue;
            Assert.AreEqual(fireBall.DefenseValue, actual);
        }

        [Test]
        public void MultipleSpellsGetDefenseValueTest()
        {
            SpellsBook spellsBook = new SpellsBook();
            ISpell fireBall = new FireBall();
            ISpell fireBall2 = new FireBall();
            ISpell fireBall3 = new FireBall();
            spellsBook.Spells = new ISpell[]{ fireBall, fireBall2, fireBall3 };
            int actual = spellsBook.DefenseValue;
            Assert.AreEqual(fireBall.DefenseValue + fireBall2.DefenseValue + fireBall3.DefenseValue, actual);
        }
    }
}