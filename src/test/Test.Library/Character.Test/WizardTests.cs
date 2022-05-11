using NUnit.Framework;
using RoleplayGame;
using System.Collections.Generic;

namespace Test.Library
{
    public class WizardTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NoSpellsBookAttackValueTest()
        {
            ICharacter<IMageItem> wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            wizard.EquipItem(staff);
            int actual = wizard.AttackValue;
            Assert.AreEqual(staff.AttackValue, actual);
        }

        [Test]
        public void WithSpellsBookAttackValueTest()
        {
            ICharacter<IMageItem> wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            SpellsBook spellsBook = new SpellsBook();
            ISpell fireBall = new FireBall();
            spellsBook.Spells = new ISpell[]{ fireBall };
            wizard.EquipItem(staff);
            wizard.EquipItem(spellsBook);
            
            int actual = wizard.AttackValue;
            Assert.AreEqual(staff.AttackValue + fireBall.AttackValue, actual);
        }
        
        [Test]
        public void NoSpellsBookDefenseValueTest()
        {
            ICharacter<IMageItem> wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            wizard.EquipItem(staff);
            int actual = wizard.DefenseValue;
            Assert.AreEqual(staff.DefenseValue, actual);
        }

        [Test]
        public void WithSpellsBookDefenseValueTest()
        {
            ICharacter<IMageItem> wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            SpellsBook spellsBook = new SpellsBook();
            ISpell fireBall = new FireBall();
            spellsBook.Spells = new ISpell[]{ fireBall };
            wizard.EquipItem(staff);
            wizard.EquipItem(spellsBook);
            
            int actual = wizard.DefenseValue;
            Assert.AreEqual(staff.DefenseValue + fireBall.DefenseValue, actual);
        }

        [Test]
        public void NoItemsWizardRecieveAttackTest()
        {
            ICharacter<IMageItem> wizard = new Wizard("gandalf");
            wizard.ReceiveAttack(10);
            int actual = wizard.Health;
            Assert.AreEqual(100 - 10, actual);
        }

        [Test]
        public void NoSpellsBookRecieveAttackTest()
        {
            ICharacter<IMageItem> wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            wizard.EquipItem(staff);
            wizard.ReceiveAttack(110);
            int actual = wizard.Health;
            Assert.AreEqual(100 - (110 - staff.DefenseValue), actual);
        }

        [Test]
        public void WithSpellsBookRecieveAttackTest()
        {
            ICharacter<IMageItem> wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            SpellsBook spellsBook = new SpellsBook();
            ISpell fireBall = new FireBall();
            spellsBook.Spells = new ISpell[]{ fireBall };
            wizard.EquipItem(staff);
            wizard.EquipItem(spellsBook);
            wizard.ReceiveAttack(230);
            int actual = wizard.Health;
            Assert.AreEqual(100 - (230 - (staff.DefenseValue + fireBall.DefenseValue)), actual);
        }

        [Test]
        public void CureTest()
        {
            ICharacter<IMageItem> wizard = new Wizard("gandalf");
            wizard.ReceiveAttack(50);
            wizard.Cure();
            int actual = wizard.Health;
            Assert.AreEqual(100, actual);
        }

        [Test]
        public void EquipAlreadyExistingItemTest()
        {
            Wizard wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            wizard.EquipItem(staff);
            wizard.EquipItem(staff);
            List<IMageItem> expected = new List<IMageItem>{staff};
            List<IMageItem> actual = wizard.Items;
            Assert.AreEqual(expected, actual);
        }
    }
}