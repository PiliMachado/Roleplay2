using NUnit.Framework;
using RoleplayGame;
using System;
using System.Collections.Generic;

namespace Test.Library
{


    public class DwarfTests
    {
        /// <summary>
        /// Verificamos que el daño se aplique correctamente
        /// </summary>
        [Test]
        public void BasicAttackTest()
        {
            Archer archer = new Archer("Jose pedro");
            Archer archer2 = new Archer("Pablito");

            archer2.OffensiveItems.AddRange(new IOffensiveItem[]{new Bow(), new Bow(), new Bow()});

            archer.ReceiveAttack(archer2.AttackValue);

            Assert.AreEqual(
                100-(archer2.AttackValue > archer.DefenseValue ? 
                archer2.AttackValue - archer.DefenseValue :
                 0),
             archer.Health);
        }

        // [Test]
        // public void AddItemTest() // Verificamos que se puedan agregar items a la lista de items, y que estos no se vean repetidos.
        // {
        //     Item Sword = new Item(30, 0, 20);
        //     Item Orb = new Item(30, 0, 20);
        //     List<Item> expected = new List<Item>();
        //     expected.Add(Sword);
        //     expected.Add(Orb);
        //     Dwarf Goliath = new Dwarf("Goliath", 30, 200, 0); 
        //     Goliath.AddItem(Sword);
        //     Goliath.AddItem(Orb);
        //     Goliath.AddItem(Sword);
        //     Assert.AreEqual(Goliath.Items, expected);
        // }
        
    }
}