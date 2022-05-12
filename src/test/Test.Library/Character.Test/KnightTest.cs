using NUnit.Framework;
using RoleplayGame;
using System.Collections.Generic;

namespace Test.Library
{
    public class KnightTest
    {

        [Test]
        public void KnightDefensiveValueTest()
        {
            Knight knight = new Knight("Blou");
            IDefensiveItem armor = new Armor();
            knight.EquipItem(armor);
            int defensevalue = knight.DefenseValue;
            Assert.AreEqual(armor.DefenseValue, defensevalue);
        }

        [Test]
        public void KnightRecieveAttackTest()
        {
            Knight knight = new Knight("Blou");
            knight.ReceiveAttack(50);
            int healthremaining = knight.Health;
            int allLife = 100;
            Assert.AreEqual(allLife - 50, healthremaining);
        }

        [Test]
        public void KnightfWhitItemRecieveAttackTest()
        {
            Knight knight = new Knight("Blou");
            IDefensiveItem armor = new Armor();
            knight.EquipItem(armor);
            knight.ReceiveAttack(100);
            int healthremaining = knight.Health;
            int allLife = 100;

            Assert.AreEqual(allLife - (100 - armor.DefenseValue), healthremaining);
        }

        [Test]
        public void KnightAttackValueTest()
        {
            Knight knight = new Knight("Blou");
            IOffensiveItem axe = new Axe();
            knight.EquipItem(axe);
            int attackvalue = knight.AttackValue;
            Assert.AreEqual(axe.AttackValue, attackvalue);
        }

        [Test]
        public void KnightCureTest()
        {
            Knight knight = new Knight("Blou");
            knight.ReceiveAttack(30);
            knight.Cure();
            int healedhealth = knight.Health;
            Assert.AreEqual(100, healedhealth);
        }

        [Test]
        public void KnightEquipAnAlreadyEquippedItem() // Testeamos que no se puedan repetir items en la lista de items.
        {
            Knight Knight = new Knight("Blou");
            IOffensiveItem Axe = new Axe();
            Knight.EquipItem(Axe);
            Knight.EquipItem(Axe);
            List<IOffensiveItem> itemlist = new List<IOffensiveItem> { Axe };
            List<IOffensiveItem> equipped = Knight.OffensiveItems;
            Assert.AreEqual(itemlist, equipped);
        }

        [Test]
        public void KnightRemoveUnEquippedItem() // Testeamos que no salte una excepcion al intentar de remover un item que no se encuentre en la lista de items.
        {
            Knight Knight = new Knight("Blou");
            IOffensiveItem Axe = new Axe();
            Knight.UnequipItem(Axe);
            Assert.Pass();
        }
    }
}