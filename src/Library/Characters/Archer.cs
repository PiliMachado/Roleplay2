using System.Collections.Generic;

namespace RoleplayGame
{
    public class Archer : ICharacter
    {
        private int health = 100;

        public string Name { get; set; }
        
        public List<IDefensiveItem> DefensiveItems {get; private set;} = new List<IDefensiveItem>();
        public List<IOffensiveItem> OffensiveItems {get; private set;} = new List<IOffensiveItem>();

        public Archer(string name)
        {
            this.Name = name;
        }

        
        public void EquipItem(IDefensiveItem item)
        {
            if(!this.DefensiveItems.Contains(item))
            {
                this.DefensiveItems.Add(item);
            }
        }
        public void EquipItem(IOffensiveItem item)
        {
            if(!this.OffensiveItems.Contains(item))
            {
                this.OffensiveItems.Add(item);
            }
        }
        public void UnequipItem(IOffensiveItem item)
        {
            if(this.OffensiveItems.Contains(item))
            {
                this.OffensiveItems.Remove(item);
            }
        }
        public void UnequipItem(IDefensiveItem item)
        {
            if(this.DefensiveItems.Contains(item))
            {
                this.DefensiveItems.Remove(item);
            }
        }
        public int AttackValue
        {
            get
            {
                int value = 0;
                foreach(IOffensiveItem item in this.OffensiveItems)
                {
                    value += item.AttackValue;
                }
                return value;
            }
        }

        public int DefenseValue
        {
            get
            {
                int value = 0;
                foreach(IDefensiveItem item in this.DefensiveItems)
                {
                    value += item.DefenseValue;
                }
                return value;
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