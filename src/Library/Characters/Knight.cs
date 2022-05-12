using System.Collections.Generic;
namespace RoleplayGame
{
    /// <summary>
    /// La clase Knight implementa ICharacter ya que estos manejan un nivel de vida, pueden ser atacados, 
    /// pueden ser curados y pueden tener items
    /// </summary>
    public class Knight : ICharacter
    {
        private int health = 100;

        public Knight(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        /// <summary>
        /// Las 2 listas de items de Knight son del tipo IOffensiveItem y IDefensiveItem ya que hay ciertos items que solo
        /// son ofensivos, y otros que son solo defensivos.
        /// </summary>
        /// <typeparam name=""></typeparam>
        /// <returns></returns>
        public List<IDefensiveItem> DefensiveItems { get; private set; } = new List<IDefensiveItem>();
        public List<IOffensiveItem> OffensiveItems { get; private set; } = new List<IOffensiveItem>();

        /// <summary>
        /// Los items de un Knight pueden ser Ofensivos y/o Defensivos, asi que al agregar items a la lista de item como parametro
        /// debemos agregar IDefensiveItem si es para los items defensivos, y IOffensiveItem si es para los items ofensivos, 
        /// para aplicar esto podemos hacer sobrecarga.
        /// </summary>
        /// <param name="item"></param>
        public void EquipItem(IDefensiveItem item)
        {
            if(!this.DefensiveItems.Contains(item)) // Verificar que no este ya el item en la lista de items.
            {
                this.DefensiveItems.Add(item);
            }
        }
        public void EquipItem(IOffensiveItem item)
        {
            if(!this.OffensiveItems.Contains(item)) // Verificar que no este ya el item en la lista de items.
            {
                this.OffensiveItems.Add(item);
            }
        }
        public void UnequipItem(IOffensiveItem item)
        {
            if(this.OffensiveItems.Contains(item)) // Verificar que este ya el item en la lista de items.
            {
                this.OffensiveItems.Remove(item);
            }
        }
        public void UnequipItem(IDefensiveItem item)
        {
            if(this.DefensiveItems.Contains(item)) // Verificar que este ya el item en la lista de items.
            {
                this.DefensiveItems.Remove(item);
            }
        }
        public int AttackValue
        {
            get
            {
                /// <summary>
                /// Modificamos el attackvalue ya que ahora los items se encuentran en una lista, si se crean mas items
                /// aparte de axe, no hay que cambiar la clase Knight sino solo agregar clases de esos nuevos items
                /// que implementen IOffensiveItem.
                /// 
                /// El attackvalue lo seteamos en 0 en un inicio porque si Knight no tiene items significa que no tiene daño entonces.
                /// </summary>
                int totalAttack = 0;
                foreach(IOffensiveItem item in this.OffensiveItems)
                {
                    totalAttack += item.AttackValue;
                }
                return totalAttack;
            }
        }

        public int DefenseValue
        {
            get
            {
                /// <summary>
                /// Modificamos el defensevalue ya que ahora los items se encuentran en una lista, si se crean mas items
                /// aparte de armor, no hay que cambiar la clase Knight sino solo agregar clases de esos nuevos items
                /// que implementen IDefensiveItem.
                /// 
                /// El defensevalue lo seteamos en 0 en un inicio porque si Knight no tiene items significa que no tiene defensa entonces.
                /// </summary>
                int totalDefense = 0;
                foreach(IDefensiveItem item in this.DefensiveItems)
                {
                    totalDefense += item.DefenseValue;
                }
                return totalDefense;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value < 0 ? 0 : value;
            }
        }

        public void ReceiveAttack(int power)
        {
            if (this.DefenseValue < power)
            {
                this.Health -= power - this.DefenseValue;
            }
        }

        public void Cure()
        {
            this.Health = 100;
        }
    }
}