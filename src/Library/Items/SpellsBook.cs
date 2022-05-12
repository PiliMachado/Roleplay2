using System.Collections.Generic;

namespace RoleplayGame
{
    /// <summary>
    /// El SpellsBook es una clase que implementa IMageItem, ya que este item es del tipo
    /// magico que solo pueden usar los wizards.
    /// </summary>
    public class SpellsBook : IMageItem
    {
        /// <summary>
        /// Ahora en vez de depender de una clase Spell dependemos de una ISpell, para asi permitir
        /// que existan varios spells unos distintos de otros en sus atributos, una explicacion mas 
        /// extensa esta en ISpell.
        /// </summary>
        /// <value></value>
        public ISpell[] Spells { get; set; }
        
        public int AttackValue
        {
            get
            {
                int value = 0;
                foreach (ISpell Spell in this.Spells)
                {
                    value += Spell.AttackValue;
                }
                return value;
            }
        }

        public int DefenseValue
        {
            get
            {
                int value = 0;
                foreach (ISpell Spell in this.Spells)
                {
                    value += Spell.DefenseValue;
                }
                return value;
            }
        }
    }
}