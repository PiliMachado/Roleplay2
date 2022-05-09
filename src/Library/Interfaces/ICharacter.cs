using System;

namespace RoleplayGame
{
    /// <summary>
    /// Contiene las caracteristicas generales de los personajes.
    /// </summary>
    public interface ICharacter
    {
        int BaseHealth {get; private set;}
        int BaseDamage {get; private set;}
        int BaseDefense {get; private set;}
        
        int Health {get; set; }
        int AttackValue {get; }

        int DefenseValue {get; }

        void Attack(ICharacter character);
        void Cure();


    }
}
