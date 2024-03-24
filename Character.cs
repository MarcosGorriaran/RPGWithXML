using System.Xml.Serialization;

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
        /*
         Este objeto de serializacion en XML tiene muchas similitudes al serializador que utilizamos
         en acceso de datos para JSON.
         */
        public void XMLSerialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StreamWriter file = new StreamWriter(path))
            {
                serializer.Serialize(file, this);
            }
        }
        public static Character XMLDeserialize(string path)
        {
            Character result = new Character();
            XmlSerializer serializer = new XmlSerializer(result.GetType());
            
            using (StreamReader file = new StreamReader(path))
            {
                result = (Character)serializer.Deserialize(file);
            }
            return result;
        }
        public static void XMLSerialize(string path,params Character[] chars)
        {
            XmlSerializer serializer = new XmlSerializer(chars.GetType());
            using (StreamWriter file = new StreamWriter(path))
            {
                serializer.Serialize(file, chars);
            }
        }
        public static List<Character> XMLDeserializeGroup(string path)
        {
            List<Character> result = new List<Character>();
            XmlSerializer serializer = new XmlSerializer(result.ToArray().GetType());
            using(StreamReader file = new StreamReader(path))
            {
                result = new List<Character>((Character[])serializer.Deserialize(file));
            }
            return result;
        }
        public bool IsCharAlive()
        {
            return this.Health > 0;
        }
        public static bool AreCharsAlive(params Character[] chars)
        {
            foreach(Character chara in chars)
            {
                if (!chara.IsCharAlive())
                {
                    return false;
                }
            }
            return true;
        }
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