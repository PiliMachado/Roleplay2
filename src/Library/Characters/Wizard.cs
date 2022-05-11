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

        public void EquipItem(IMageItem item)
        {
            if(!this.Items.Contains(item))
            {
                this.Items.Add(item);
            }
        }
        public void UnequipItem(IMageItem item)
        {
            if(this.Items.Contains(item))
            {
                this.Items.Remove(item);
            }
        }
        public int AttackValue
        {
            get
            {
                int attackValue = 0;
                foreach(IMageItem item in this.Items)
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
                int defenseValue = 0;
                foreach(IMageItem item in this.Items)
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