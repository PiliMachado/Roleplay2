using System.Collections.Generic;

namespace RoleplayGame
{
    public class Archer : ICharacter
    {
        private int health = 100;

        public string Name { get; set; }
        
        public List<IDefensiveItems> defensiveItems {get; private set;} = new List<IDefensiveItems>();
        public List<IOffensiveItems> offensiveItems {get; private set;} = new List<IOffensiveItems>();

        public Archer(string name)
        {
            this.Name = name;
        }

        public int AttackValue
        {
            get
            {
                int value = 0;
                foreach(IOffensiveItems item in this.offensiveItems)
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
                foreach(IDefensiveItems item in this.defensiveItems)
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