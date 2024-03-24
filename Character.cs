namespace RPGWithXML
{
    public class Character
    {
        const uint StartLevel = 0;
        const string DefaultName = "DefaultName";
        const int DefaultHealth = 0;
        const uint DefaultAttack = 0;
        const uint DefaultDefense = 0;

        public string Name { get; set; }
        public uint Level { get; set; }
        public int Health { get; set; }    
        public uint Attack { get; set; }
        public uint Defense { get; set; }


        public Character(string name, uint level, int health, uint attack, uint defense)
        {
            this.Name = name;
            this.Level = level;
            this.Health = health;
            this.Attack = attack;
            this.Defense = defense;
        }

        public Character(string name, int health, uint attack, uint defense) : this (name, StartLevel, health, attack, defense) 
        { }

        public Character() : this (DefaultName, DefaultHealth, DefaultAttack, DefaultDefense)
        { }

        public override string ToString()
        {
            string returnVal = $"Name: {this.Name}{Environment.NewLine}";
            returnVal += $"Level: {this.Level}{Environment.NewLine}";
            returnVal += $"MaxHP: {this.Health}{Environment.NewLine}";
            returnVal += $"Attack: {this.Attack}{Environment.NewLine}";
            returnVal += $"Defense: {this.Defense}{Environment.NewLine}";
            return returnVal;
        }
    }
}