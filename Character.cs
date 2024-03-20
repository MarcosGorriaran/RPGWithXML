namespace RPGWithXML
{
    public class Character
    {
        const uint StartLevel = 0;
        public string Name { get; set; }
        public uint Level { get; set; }
        public uint Attack { get; set; }
        public uint Defense { get; set; }

        public Character(string name, uint level,uint attack, uint defense)
        {
            this.Name = name;
            this.Level = level;
            this.Attack = attack;
            this.Defense = defense;
        }
        public Character(string name, uint attack, uint defense):this(name,StartLevel,attack,defense) 
        {
        
        }
        public override string ToString()
        {
            string returnVal = $"Name: {this.Name}{Environment.NewLine}";
            returnVal += $"Attack: {this.Attack}{Environment.NewLine}";
            returnVal += $"Defense: {this.Defense}{Environment.NewLine}";
            returnVal += $"Level: {this.Level}{Environment.NewLine}";
            return returnVal;
        }
    }
}
