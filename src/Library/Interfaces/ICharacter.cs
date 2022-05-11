using System;

namespace RoleplayGame
{
    /// <summary>
    /// Contiene las caracteristicas generales de los personajes. Un nivel de vida, pueden ser atacados, 
    /// pueden ser curados y pueden tener items.
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
