using System;

namespace RoleplayGame
{
    /// <summary>
    /// Contiene las caracteristicas generales de los personajes.
    /// </summary>
    public interface ICharacter
    {
        int Health {get; }
        string Name {get; set;}
        int AttackValue {get; }
        int DefenseValue {get; }

        void ReceiveAttack(int power);
        void Cure();


    }
}
