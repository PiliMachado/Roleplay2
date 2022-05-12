using System;

namespace RoleplayGame
{
    /// <summary>
    /// Contiene las caracteristicas generales de los personajes. Un nivel de vida, pueden ser atacados por lo cual precisamos de un defenseValue y
    /// como tambien cuando ataquemos a otros pasaremos el ataque a un receiveattack entonces precisamos attackValue, para saber
    /// cuanto ataque es el total, los characters tambien pueden ser curados.
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
