using System;

namespace RoleplayGame
{
    /// <summary>
    /// Contiene las caracteristicas generales de los personajes.
    /// </summary>
    public interface ICharacter
    {
        int BaseHealth {get; set;}
        int BaseDamage {get; set;}
        int BaseDefense {get; set;}
        
        int Health {get; set; }
        int AttackValue {get; }

        int DefenseValue {get; }

        void Attack(ICharacter character);
        void Cure();


    }
}
