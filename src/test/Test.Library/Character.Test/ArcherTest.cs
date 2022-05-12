using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class DwarfTests
    {
        /// <summary>
        /// Verificamos que el daño se aplique correctamente.
        /// </summary>
        [Test]
        public void ArcherAttackTest()
        {
            Archer archer = new Archer("Jose pedro");
            Archer archer2 = new Archer("Pablito");

            foreach(IOffensiveItem item in new IOffensiveItem[]{new Bow(), new Bow(), new Bow()})
            {
                archer.EquipItem(item);
            }
            archer.ReceiveAttack(archer2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(archer2.AttackValue > archer.DefenseValue ? 
                    archer2.AttackValue - archer.DefenseValue :
                    0)
                 ),
             archer.Health);
        }


        /// <summary>
        /// Verificamos que la defensa tenga efecto al momento de recibir un ataque.
        /// </summary>
        [Test]
        public void ArcherDefenseTest()
        {
            Archer archer = new Archer("Jose pedro");
            Archer archer2 = new Archer("Pablito");

            foreach(IDefensiveItem item in new IDefensiveItem[]{new Helmet(), new Helmet(), new Helmet()})
            {
                archer.EquipItem(item);
            }
            archer.ReceiveAttack(archer2.AttackValue);

            Assert.AreEqual(
                Math.Max(0,
                    100-(archer2.AttackValue > archer.DefenseValue ? 
                    archer2.AttackValue - archer.DefenseValue :
                    0)
                 ),
             archer.Health);
        }

        [Test]
        public void ArcherAttackValueTest()
        {
            Archer archer = new Archer("Jose pedro");
            foreach(IOffensiveItem item in new IOffensiveItem[]{new Bow(), new Bow(), new Bow()})
            {
                archer.EquipItem(item);
            }
            int expected = new Bow().AttackValue*3;

            Assert.AreEqual(expected, archer.AttackValue);
        }

        [Test]
        public void ArcherDefenseValueTest()
        {
            Archer archer = new Archer("Jose pedro");

            foreach(IDefensiveItem item in new IDefensiveItem[]{new Helmet(), new Helmet(), new Helmet()})
            {
                archer.EquipItem(item);
            }
            int expected = new Helmet().DefenseValue*3;

            Assert.AreEqual(expected, archer.DefenseValue);
        }

        [Test]
        public void ArcherEquipItemTest()
        {
            Archer archer = new Archer("Jose pedro");

            archer.EquipItem(new Helmet());
            archer.EquipItem(new Bow());

            Assert.AreEqual(1, archer.DefensiveItems.Count);
            Assert.AreEqual(1, archer.OffensiveItems.Count);
        }

        [Test]
        public void ArcherCannotEquipAlreadyEquippedItemTest()
        {
            Archer archer = new Archer("Jose pedro");

            IDefensiveItem helmet = new Helmet();
            archer.EquipItem(helmet);
            archer.EquipItem(helmet);
            
            Assert.AreEqual(1, archer.DefensiveItems.Count);
        }

        [Test]
        public void ArcherDequipItemTest()
        {
            Archer archer = new Archer("Jose pedro");


            IDefensiveItem helmet = new Helmet();
            archer.EquipItem(helmet);

            Assert.AreEqual(1, archer.DefensiveItems.Count);

            archer.UnequipItem(helmet);
            
            Assert.AreEqual(0, archer.DefensiveItems.Count);
        }

        [Test]
        public void ArcherCannotDequipNotEquippedItemTest()
        {
            Archer archer = new Archer("Jose pedro");

            IDefensiveItem helmet = new Helmet();

            archer.EquipItem(new Helmet());
            archer.UnequipItem(helmet);

            Assert.AreEqual(1, archer.DefensiveItems.Count);
        }
        
    }
}