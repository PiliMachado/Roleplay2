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
        public void NoSpellsBookAttackValueTest() // Testeamos que el calculo del ataque sin spellsbook, es decir, solo con staff sea el esperado.
        {
            Wizard wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            wizard.EquipItem(staff);
            int actual = wizard.AttackValue;
            Assert.AreEqual(staff.AttackValue, actual);
        }

        [Test]
        public void WithSpellsBookAttackValueTest() // Testeamos que el calculo del ataque con spellsbook, sea el esperado.
        {
            Wizard wizard = new Wizard("gandalf");
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
        public void NoSpellsBookDefenseValueTest() // Testeamos que le calculo de la defensa sin el spellbooks sea el esperado.
        {
            Wizard wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            wizard.EquipItem(staff);
            int actual = wizard.DefenseValue;
            Assert.AreEqual(staff.DefenseValue, actual);
        }

        [Test]
        public void WithSpellsBookDefenseValueTest() // Testeamos que el calculo de la defensa de un wizard con spellsbook sea el esperado.
        {
            Wizard wizard = new Wizard("gandalf");
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
        public void NoItemsWizardRecieveAttackTest() // Testeamos que el wizard sin ningun item reciba un ataque y cambie su valor de vida de la forma esperada.
        {
            Wizard wizard = new Wizard("gandalf");
            wizard.ReceiveAttack(10);
            int actual = wizard.Health;
            Assert.AreEqual(100 - 10, actual);
        }

        [Test]
        public void NoSpellsBookRecieveAttackTest() // Testeamos que el wizard sin spellsbook pero con un item reciba un ataque y cambie su valor de vida de la forma esperada.
        {
            Wizard wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            wizard.EquipItem(staff);
            wizard.ReceiveAttack(110);
            int actual = wizard.Health;
            Assert.AreEqual(100 - (110 - staff.DefenseValue), actual);
        }

        [Test]
        public void WithSpellsBookRecieveAttackTest() // Testeamos que el wizard con spellsbook reciba un ataque y cambie su vida de la forma esperada.
        {
            Wizard wizard = new Wizard("gandalf");
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
        public void CureTest() // Testeamos que un wizard se cure toda su Health al usar el metodo Cure.
        {
            Wizard wizard = new Wizard("gandalf");
            wizard.ReceiveAttack(50);
            wizard.Cure();
            int actual = wizard.Health;
            Assert.AreEqual(100, actual);
        }

        [Test]
        public void EquipItemTest() // Testemos que un wizard pueda agregar un item a su lista de items.
        {
            Wizard wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            wizard.EquipItem(staff);
            List<IMageItem> expected = new List<IMageItem>{staff};
            List<IMageItem> actual = wizard.Items;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EquipAlreadyExistingItemTest() // Testemos que un wizard no pueda tener items repetidos en su lista de items.
        {
            Wizard wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            wizard.EquipItem(staff);
            wizard.EquipItem(staff);
            List<IMageItem> expected = new List<IMageItem>{staff};
            List<IMageItem> actual = wizard.Items;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnequipNotEquippedItemTest() // Testemos que un wizard no pueda remover items que no tenga su lista de items. (Que no salte una excepcion)
        {
            Wizard wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            wizard.UnequipItem(staff);
            Assert.Pass();
        }

        [Test]
        public void UnequipEquippedItemTest() // Testemos que un wizard pueda remover items que tenga su lista de items.
        {
            Wizard wizard = new Wizard("gandalf");
            IMageItem staff = new Staff();
            wizard.EquipItem(staff);
            wizard.UnequipItem(staff);
            List<IMageItem> expected = new List<IMageItem>();
            Assert.AreEqual(expected, wizard.Items);
        }
    }
}