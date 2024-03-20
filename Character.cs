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
    }
}
