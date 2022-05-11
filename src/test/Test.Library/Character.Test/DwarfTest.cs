using NUnit.Framework;
using RoleplayGame;
using System.Collections.Generic;

namespace Test.Library
{
    public class DwarfTest
    {
        [Test]
        public void DwarfAttackValueTest()
        {
            Dwarf dwarf = new Dwarf("Albus");
            IOffensiveItem sword = new Sword();
            dwarf.EquipItem(sword);
            int attackvalue = dwarf.AttackValue;
            Assert.AreEqual(sword.AttackValue, attackvalue);
        }

        [Test]
        public void DwarfDefensiveValueTest()
        {
            Dwarf dwarf = new Dwarf("Albus");
            IDefensiveItem helmet = new Helmet();
            dwarf.EquipItem(helmet);
            int defensevalue = dwarf.DefenseValue;
            Assert.AreEqual(helmet.DefenseValue, defensevalue);
        }

        [Test]
        public void DwarfRecieveAttackTest()
        {
            Dwarf dwarf = new Dwarf("Albus");
            dwarf.ReceiveAttack(50);
            int healthremaining = dwarf.Health;
            Assert.AreEqual(100 - 50, healthremaining);
        }

        [Test]
        public void DwarfWhitItemRecieveAttackTest()
        {
            Dwarf dwarf = new Dwarf("Albus");
            IDefensiveItem helmet = new Helmet();
            dwarf.EquipItem(helmet);
            dwarf.ReceiveAttack(110);
            int healthremaining = dwarf.Health;

            Assert.AreEqual(100 - (110 - helmet.DefenseValue), healthremaining);
        }

        [Test]
        public void DwarfCureTest()
        {
            Dwarf dwarf = new Dwarf("Albus");
            dwarf.ReceiveAttack(50);
            dwarf.Cure();
            int healedhealth = dwarf.Health;
            Assert.AreEqual(100, healedhealth);
        }

        [Test]
        public void DwarfEquipAnAlreadyEquippedItem()
        {
            Dwarf dwarf = new Dwarf("Albus");
            IOffensiveItem sword = new Sword();
            dwarf.EquipItem(sword);
            dwarf.EquipItem(sword);
            List<IOffensiveItem> itemlist = new List<IOffensiveItem> { sword };
            List<IOffensiveItem> equipped = dwarf.OffensiveItems;
            Assert.AreEqual(itemlist, equipped);
        }
    }
}