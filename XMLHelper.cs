using System.Xml.Linq;

namespace RPGWithXML
{
    public class XMLHelper
    {
        const string CharacterClassName = "character";
        const string CharactersName = "characters";
        const string CharName = "name";
        const string CharLevel = "level";
        const string CharHP = "health";
        const string CharAttack = "attack";
        const string Defense = "defense";

        public static void AddCharacterToXMLFile(string filePath, string name, uint level, int health, uint attack, uint defense)
        {
            List<Character> characters;
            try
            {
                characters = Character.XMLDeserializeGroup(filePath);
            }
            catch (FileNotFoundException)
            {
                characters = new List<Character>();
            }
            
            characters.Add(new Character(name,level,health,attack,defense));

            Character.XMLSerialize(filePath, characters.ToArray());
            
        }

        public static string PrintResult(List<Character> characters)
        {
            string result="";
            foreach (var character in characters)
            {
                result += character + Environment.NewLine;
            }
            return result;
        }

        //Lee un personaje en especifico, por el nombre (Este metodo lo usaremos para el combate)
        public static Character SelectCharacter(string filePath, string specificName)
        {
            List<Character> xmlDoc = Character.XMLDeserializeGroup(filePath);

            var character = (from selection in xmlDoc
                             where selection.Name == specificName
                             select selection);

            return character.First<Character>();
        }

        //USING LINQ TO XML: UPDATE XML FILE
        public static void UpdateXMLFile (string filePath,string specificName, string name, uint level, int health, uint attack, uint defense)
        {
            List<Character> characters = Character.XMLDeserializeGroup(filePath);
            bool found=false;

            for (int i = 0; i < characters.Count; i++) 
            {
                if (characters[i].Name == specificName)
                {
                    characters[i].Name = name;
                    characters[i].Level = level;
                    characters[i].Health = health;
                    characters[i].Attack = attack;
                    characters[i].Defense = defense;
                    found = true;
                }
            }
            
            if (!found)
            {
                throw new Exception();
            }
            Character.XMLSerialize(filePath, characters.ToArray());
        }
    }
}
