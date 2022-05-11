using System.Collections.Generic;

namespace RoleplayGame
{
    /// <summary>
    /// El SpellsBook es una clase que implementa IMageItem, ya que este item es del tipo
    /// magico que solo pueden usar los wizards.
    /// </summary>
    public class SpellsBook : IMageItem
    {
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