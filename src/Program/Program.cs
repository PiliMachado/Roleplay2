using System;
using RoleplayGame;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            SpellsBook book = new SpellsBook();
            book.Spells = new ISpell[]{ new FireBall() };

            Wizard gandalf = new Wizard("Gandalf");
            /*
            gandalf.Staff = new Staff();
            gandalf.SpellsBook = book;
            */
            IMageItem staff = new Staff();
            gandalf.EquipItem(staff);

            Dwarf gimli = new Dwarf("Gimli");
            IOffensiveItem Axe = new Axe();
            IDefensiveItem Helmet = new Helmet();
            gimli.EquipItem(Axe);
            gimli.EquipItem(Helmet);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
            Console.WriteLine($"Gandalf attacks Gimli with ⚔️ {gandalf.AttackValue}");

            gimli.ReceiveAttack(gandalf.AttackValue);

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");

            gimli.Cure();

            Console.WriteLine($"Gimli has ❤️ {gimli.Health}");
        }
    }
}
