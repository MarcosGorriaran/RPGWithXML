using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace RPGWithXML
{
    public class XMLHelper
    {
        //USING LINQ TO XML: CREATE XML FILE
        public static void CreateXMLFile(string filePath, string name, uint level, int health, uint attack, uint defense)
        {
            XDocument xmlDoc = new XDocument(
                new XElement("characters",
                    new XElement("character",
                        new XElement("name", name),
                        new XElement("level", level),
                        new XElement("health", health),
                        new XElement("attack", attack),
                        new XElement("defense", defense)
                    )
                )
            );

            //filePath => "direccion path";
            xmlDoc.Save(filePath);

            Console.WriteLine("Documento XML creado correctamente.");
        }

        //USING LINQ TO XML: ADD NEW CHARACTER TO XML FILE
        public static void AddCharacterToXMLFile(string filePath, string name, uint level, int health, uint attack, uint defense)
        {
            XDocument xmlDoc = XDocument.Load(filePath);

            XElement newCharacter = new XElement("character",
                                            new XElement("name", name),
                                            new XElement("level", level),
                                            new XElement("health", health),
                                            new XElement("attack", attack),
                                            new XElement("defense", defense)
                                        );

            xmlDoc.Root.Add(newCharacter);

            xmlDoc.Save(filePath);

            Console.WriteLine("Nuevo personaje añadido al documento XML correctamente.");
        }

        //USING LINQ TO XML: READ XML FILE
        public static List<Character> ReadXMLFile(string filePath)
        {
            XDocument xmlDoc = XDocument.Load(filePath);

            //Lee todos los elementos "character" dentro de "characters" y los convierte en objetos Character
            var characters = from character in xmlDoc.Descendants("character")
                             select new Character
                             {
                                 Name = character.Element("name").Value,
                                 Level = Convert.ToUInt32(character.Element("level").Value),
                                 Health = Convert.ToInt32(character.Element("health").Value),
                                 Attack = Convert.ToUInt32(character.Element("attack").Value),
                                 Defense = Convert.ToUInt32(character.Element("defense").Value)
                             };

            //"characters" es de tipo IEnumerable<T>, con .ToList() lo convertimos a List<Character>
            return characters.ToList(); 
        }

        public static void PrintResult(List<Character> characters)
        {
            foreach (var character in characters)
            {
                Console.WriteLine($"Name: {character.Name}");
                Console.WriteLine($"Level: {character.Level}");
                Console.WriteLine($"Health: {character.Health}");
                Console.WriteLine($"Attack: {character.Attack}");
                Console.WriteLine($"Defense: {character.Defense}");
                Console.WriteLine();
            }
        }

        //Lee un personaje en especifico, por el nombre (Este metodo lo usaremos para el combate)
        public static Character SelectCharacter(string filePath, string specificName)
        {
            XDocument xmlDoc = XDocument.Load(filePath);

            var character = (from selection in xmlDoc.Descendants("character")
                             where selection.Element("name").Value == specificName
                             select new Character
                             {
                                 Name = selection.Element("name").Value,
                                 Level = Convert.ToUInt32(selection.Element("level").Value),
                                 Health = Convert.ToInt32(selection.Element("health").Value),
                                 Attack = Convert.ToUInt32(selection.Element("attack").Value),
                                 Defense = Convert.ToUInt32(selection.Element("defense").Value)
                             }).SingleOrDefault(); ;

            return character;
        }


        //USING LINQ TO XML: UPDATE XML FILE
        public static void UpdateXMLFile (string filePath,string specificName, string name, uint level, int health, uint attack, uint defense)
        {
            XDocument xmlDoc = XDocument.Load(filePath);

            var character = xmlDoc.Descendants("character").FirstOrDefault(
                c => c.Element("name")?.Value == specificName);

            character.Element("name").Value = name;
            character.Element("level").Value = level.ToString();
            character.Element("health").Value = health.ToString();
            character.Element("attack").Value = attack.ToString();
            character.Element("defense").Value = defense.ToString();

            xmlDoc.Save(filePath);

            Console.WriteLine("Documento XML actualizado correctamente.");
        }
    }
}
