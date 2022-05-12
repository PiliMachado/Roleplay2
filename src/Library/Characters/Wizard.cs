using System.Collections.Generic;

namespace RoleplayGame
{
    /// <summary>
    /// La clase wizard implementa ICharacter ya que estos manejan un nivel de vida, pueden ser atacados, 
    /// pueden ser curados y pueden tener items
    /// </summary>
    public class Wizard : ICharacter
    {
        private int health = 100;

        public Wizard(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        /// <summary>
        /// La lista de items de wizard son del tipo IMageItem ya que hay ciertos items magicos
        /// que solo usa el wizard.
        /// </summary>
        /// <typeparam name="IMageItem"></typeparam>
        /// <returns></returns>
        public List<IMageItem> Items { get; set; } = new List<IMageItem>();

        /// <summary>
        /// Los items de un wizard son magicos, asi que al agregar items a la lista de item como parametro
        /// debemos pasar un IMageItem (ya que los items pueden ser un spellbook, staff, o otros IMageItems que se 
        /// creen a futuro)
        /// </summary>
        /// <param name="item"></param>
        public void EquipItem(IMageItem item)
        {
            // Condicional para que no se repitan items en la lista de items.
            if(!this.Items.Contains(item))
            {
                this.Items.Add(item);
            }
        }

        /// <summary>
        /// Los items de un wizard son magicos, asi que al remover items a la lista de item como parametro
        /// debemos pasar un IMageItem (ya que los items pueden ser un spellbook, staff, o otros IMageItems que se 
        /// creen a futuro)
        /// </summary>
        /// <param name="item"></param>
        public void UnequipItem(IMageItem item)
        {
            // Condicional para que no salte una excepcion si se intenta de remover un item que no se encuentra
            // en la lista de items.
            if(this.Items.Contains(item))
            {
                this.Items.Remove(item);
            }
        }
        public int AttackValue
        {
            get
            {
                /// <summary>
                /// Modificamos el attackvalue ya que ahora los items se encuentran en una lista, si se crean mas items
                /// aparte de staff y spellbooks no hay que cambiar la clase wizard sino solo agregar clases de esos nuevos items
                /// que implementen IMageItem.
                /// 
                /// El attackvalue lo seteamos en 0 en un inicio porque si wizard no tiene items significa que no tiene daño entonces.
                /// </summary>
                int attackValue = 0;
                foreach(IMageItem item in this.Items) // Para calcular el attackvalue recorremos la lista de items y vamos sumando el attackvalue de cada uno.
                {
                    attackValue += item.AttackValue;
                }
                return attackValue;
            }
        }

        public int DefenseValue
        {
            get
            {
                /// <summary>
                /// Modificamos el defensevalue ya que ahora los items se encuentran en una lista, si se crean mas items
                /// aparte de staff y spellbooks no hay que cambiar la clase wizard sino solo agregar clases de esos nuevos items
                /// que implementen IMageItem.
                /// 
                /// El defensevalue lo seteamos en 0 en un inicio porque si wizard no tiene items significa que no tiene defensa entonces.
                /// </summary>
                int defenseValue = 0;
                foreach(IMageItem item in this.Items) // Para calcular el defensevalue recorremos la lista de items y vamos sumando el defensevalue de cada uno.
                {
                    defenseValue += item.DefenseValue;
                }
                return defenseValue;
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