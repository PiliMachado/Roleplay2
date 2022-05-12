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
        public void SingleSpellGetAttackValueTest() // Testeamos que el ataque del spellbook se calcule correctamente con un unico spell.
        {
            SpellsBook spellsBook = new SpellsBook();
            ISpell fireBall = new FireBall();
            spellsBook.Spells = new ISpell[]{ fireBall };
            int actual = spellsBook.AttackValue;
            Assert.AreEqual(fireBall.AttackValue, actual);
        }

        [Test]
        public void MultipleSpellsGetAttackValueTest()  // Testeamos que el ataque del spellbook se calcule correctamente con varios spells.
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
        public void SingleSpellGetDefenseValueTest() // Testeamos que la defensa del spellbook se calcule correctamente con un unico spell.
        {
            SpellsBook spellsBook = new SpellsBook();
            ISpell fireBall = new FireBall();
            spellsBook.Spells = new ISpell[]{ fireBall };
            int actual = spellsBook.DefenseValue;
            Assert.AreEqual(fireBall.DefenseValue, actual);
        }

        [Test]
        public void MultipleSpellsGetDefenseValueTest() // Testeamos que la defensa del spellbook se calcule correctamente con varios spells.
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