using NUnit.Framework;
using RoleplayGame;
using System.Collections.Generic;

namespace Test.Library
{
    public class DwarfTest
    {
        [Test]
        public void DwarfAttackValueTest() // Testeamos que se calcule el ataque de un personaje, como el ataque de sus items, que en este caso es uno solo.
        {
            Dwarf dwarf = new Dwarf("Albus");
            IOffensiveItem sword = new Sword();
            dwarf.EquipItem(sword);
            int attackvalue = dwarf.AttackValue;
            Assert.AreEqual(sword.AttackValue, attackvalue);
        }

        [Test]
        public void DwarfDefensiveValueTest() // Testeamos que se calcule la defensa de un personaje, como el ataque de sus items, que en este caso es uno solo.
        {
            Dwarf dwarf = new Dwarf("Albus");
            IDefensiveItem helmet = new Helmet();
            dwarf.EquipItem(helmet);
            int defensevalue = dwarf.DefenseValue;
            Assert.AreEqual(helmet.DefenseValue, defensevalue);
        }

        [Test]
        public void DwarfRecieveAttackTest() // Testeamos que al recibir un ataque un dwarf sin items pierda la vida segun la cantidad que se le paso a recieveattack como parametro.
        {
            Dwarf dwarf = new Dwarf("Albus");
            dwarf.ReceiveAttack(50);
            int healthremaining = dwarf.Health;
            Assert.AreEqual(100 - 50, healthremaining);
        }

        [Test]
        public void DwarfWhitItemRecieveAttackTest() // Testeamos lo mismo que en el anterior solo que ahora hay que tener en cuenta que los items reducen el daño recibido.
        {
            Dwarf dwarf = new Dwarf("Albus");
            IDefensiveItem helmet = new Helmet();
            dwarf.EquipItem(helmet);
            dwarf.ReceiveAttack(110);
            int healthremaining = dwarf.Health;

            Assert.AreEqual(100 - (110 - helmet.DefenseValue), healthremaining);
        }

        [Test]
        public void DwarfCureTest() // Testeamos que un dwarf que halla perdido vida la recupere con Cure.
        {
            Dwarf dwarf = new Dwarf("Albus");
            dwarf.ReceiveAttack(50);
            dwarf.Cure();
            int healedhealth = dwarf.Health;
            Assert.AreEqual(100, healedhealth);
        }

        [Test]
        public void DwarfEquipAnAlreadyEquippedItem() // Testeamos que no se puedan repetir items en la lista de items.
        {
            Dwarf dwarf = new Dwarf("Albus");
            IOffensiveItem sword = new Sword();
            dwarf.EquipItem(sword);
            dwarf.EquipItem(sword);
            List<IOffensiveItem> itemlist = new List<IOffensiveItem> { sword };
            List<IOffensiveItem> equipped = dwarf.OffensiveItems;
            Assert.AreEqual(itemlist, equipped);
        }

        [Test]
        public void DwarfRemoveUnEquippedItem() // Testeamos que no salte una excepcion al intentar de remover un item que no se encuentre en la lista de items.
        {
            Dwarf dwarf = new Dwarf("Albus");
            IOffensiveItem sword = new Sword();
            dwarf.UnequipItem(sword);
            Assert.Pass();
        }
    }
}