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

        //USING LINQ TO XML: CREATE XML FILE
        public static void CreateXMLFile(string filePath, string name, uint level, int health, uint attack, uint defense)
        {
            XDocument xmlDoc = new XDocument(
                new XElement(CharactersName,
                    new XElement(CharacterClassName,
                        new XElement(CharName, name),
                        new XElement(CharLevel, level),
                        new XElement(CharHP, health),
                        new XElement(CharAttack, attack),
                        new XElement(Defense, defense)
                    )
                )
            );

            //filePath => "direccion path";
            xmlDoc.Save(filePath);

            
        }

        //USING LINQ TO XML: ADD NEW CHARACTER TO XML FILE
        public static void AddCharacterToXMLFile(string filePath, string name, uint level, int health, uint attack, uint defense)
        {
            XDocument xmlDoc = XDocument.Load(filePath);

            XElement newCharacter = new XElement(CharacterClassName,
                                            new XElement(CharName, name),
                                            new XElement(CharLevel, level),
                                            new XElement(CharHP, health),
                                            new XElement(CharAttack, attack),
                                            new XElement(Defense, defense)
                                        );

            xmlDoc.Root.Add(newCharacter);

            xmlDoc.Save(filePath);

            
        }

        //USING LINQ TO XML: READ XML FILE
        public static List<Character> ReadXMLFile(string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath);

            //Lee todos los elementos "character" dentro de "characters" y los convierte en objetos Character
            var characters = from character in xmlDoc.Descendants(CharacterClassName)
                             select new Character
                             {
                                 Name = character.Element(CharName).Value,
                                 Level = Convert.ToUInt32(character.Element(CharLevel).Value),
                                 Health = Convert.ToInt32(character.Element(CharHP).Value),
                                 Attack = Convert.ToUInt32(character.Element(CharAttack).Value),
                                 Defense = Convert.ToUInt32(character.Element(Defense).Value)
                             };

            //"characters" es de tipo IEnumerable<T>, con .ToList() lo convertimos a List<Character>
            return characters.ToList(); 
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
            XDocument xmlDoc = XDocument.Load(filePath);

            var character = (from selection in xmlDoc.Descendants(CharacterClassName)
                             where selection.Element(CharName).Value == specificName
                             select new Character
                             {
                                 Name = selection.Element(CharName).Value,
                                 Level = Convert.ToUInt32(selection.Element(CharLevel).Value),
                                 Health = Convert.ToInt32(selection.Element(CharHP).Value),
                                 Attack = Convert.ToUInt32(selection.Element(CharAttack).Value),
                                 Defense = Convert.ToUInt32(selection.Element(Defense).Value)
                             }).SingleOrDefault(); ;

            return character;
        }


        //USING LINQ TO XML: UPDATE XML FILE
        public static void UpdateXMLFile (string filePath,string specificName, string name, uint level, int health, uint attack, uint defense)
        {
            XDocument xmlDoc = XDocument.Load(filePath);

            var character = xmlDoc.Descendants(CharacterClassName).FirstOrDefault(
                c => c.Element(CharName)?.Value == specificName);

            character.Element(CharName).Value = name;
            character.Element(CharLevel).Value = level.ToString();
            character.Element(CharHP).Value = health.ToString();
            character.Element(CharAttack).Value = attack.ToString();
            character.Element(Defense).Value = defense.ToString();

            xmlDoc.Save(filePath);

            
        }
    }
}
