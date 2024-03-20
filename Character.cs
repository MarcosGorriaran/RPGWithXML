namespace RPGWithXML
{
    public class Character
    {
        const uint StartLevel = 0;
        public uint HP {  get; set; }
        public uint MaxHP { get; set; }
        public string Name { get; set; }
        public uint Level { get; set; }
        public uint Attack { get; set; }
        public uint Defense { get; set; }


        public Character(string name,uint hp,uint maxHP ,uint level,uint attack, uint defense)        {
            this.Name = name;
            this.Level = level;
            this.Attack = attack;
            this.Defense = defense;
            this.MaxHP=maxHP;
            this.HP = hp;
        }
        public Character(string name, uint hp, uint maxHP, uint attack, uint defense):this(name,hp,maxHP,StartLevel,attack,defense) 
        {
        
        }
        public override string ToString()
        {
            string returnVal = $"Name: {this.Name}{Environment.NewLine}";
            returnVal += $"Attack: {this.Attack}{Environment.NewLine}";
            returnVal += $"Defense: {this.Defense}{Environment.NewLine}";
            returnVal += $"Level: {this.Level}{Environment.NewLine}";
            returnVal += $"MaxHP: {this.MaxHP}{Environment.NewLine}";
            return returnVal;
        }
    }
}