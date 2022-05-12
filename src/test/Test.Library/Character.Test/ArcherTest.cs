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

            archer2.offensiveItems.AddRange(new IOffensiveItems[]{new Bow(), new Bow(), new Bow()});

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

        // [Test]
        // public void RemoveItemTest() // Verificamos que se puedan remover items de la lista de items, y que no surgen excepciones.
        // {
        //     Item Sword = new Item(30, 0, 20);
        //     Item Orb = new Item(30, 0, 20);
        //     List<Item> expected = new List<Item>();
        //     expected.Add(Orb);
        //     Dwarf Goliath = new Dwarf("Goliath", 30, 200, 0); 
        //     Goliath.AddItem(Sword);
        //     Goliath.AddItem(Orb);
        //     Goliath.RemoveItem(Sword);
        //     Goliath.RemoveItem(Sword);
        //     Assert.AreEqual(Goliath.Items, expected);
        // }

        // [Test]
        // public void ComplexAttackTest() // Verificamos que un ataque complejo con items haga el daño conforme a lo esperado.
        // {
        //     Item Sword = new Item(30, 0, 20);
        //     Item Orb = new Item(30, 0, 20);
        //     Dwarf Goliath = new Dwarf("Goliath", 30, 200, 0);
        //     Goliath.AddItem(Sword);
        //     Goliath.AddItem(Orb);
        //     Elf Gandalf = new Elf("Goliath", 0, 300, 20); 
        //     Goliath.Attack(Gandalf);
        //     Assert.AreEqual(Gandalf.HP, Gandalf.BaseHP + Gandalf.Defense - (Goliath.Damage + Sword.Damage + Orb.Damage));
        // }

        // [Test]
        // public void AttackingDeadCharacterTest() // Verificamos que atacar a un personaje ya muerto no cambie su vida.
        // {
        //     Item Sword = new Item(30, 0, 20);
        //     Item Orb = new Item(30, 0, 20);
        //     Dwarf Goliath = new Dwarf("Goliath", 30, 200, 0);
        //     Goliath.AddItem(Sword);
        //     Goliath.AddItem(Orb);
        //     Elf Gandalf = new Elf("Goliath", 0, 0, 20);  
        //     Goliath.Attack(Gandalf);
        //     Assert.AreEqual(Gandalf.HP, 0);
        // }

        // [Test]
        // public void BreakingItemTest() // Verificamos que tras cierta cantidad de usos un item se rompe por agotar su durabilidad.
        // {
        //     Item Sword = new Item(30, 0, 20);
        //     Item Orb = new Item(30, 0, 30);
        //     Dwarf Goliath = new Dwarf("Goliath", 120, 300, 30);
        //     Goliath.AddItem(Sword);
        //     Goliath.AddItem(Orb);
        //     Elf Gandalf = new Elf("Gandalf", 0, 300000000, 20); 
        //     for(int i = 0; i<20; i++)
        //     {
        //         Goliath.Attack(Gandalf);
        //     }
        //     Assert.AreEqual(Sword.Broken(), true);
        // }
    }
}