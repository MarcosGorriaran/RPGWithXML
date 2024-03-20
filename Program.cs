using System;
using System.Xml.Linq;
using RPGWithXML;


namespace RPGWithXML
{
    class Program
    {
        static void Main()
        {
            string path = "";
            XDocument doc = XDocument.Load(path);
            string xml;
            
            var characters = from character in doc.Descendants("Character")
            select new Character(
                character.Element("Name").Value,
                Convert.ToUInt32(character.Element("HP").Value),
                Convert.ToUInt32(character.Element("MaxHP").Value),
                Convert.ToUInt32(character.Element("Level").Value),
                Convert.ToUInt32(character.Element("Attack").Value),
                Convert.ToUInt32(character.Element("Defense").Value));
            foreach (var character in characters)
            {
                Console.WriteLine(character.ToString());

                Console.WriteLine("Presiona 1 per canviar les stats d'aquest personatge o qualsevol altre tecla per continuar:");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Introdueix el nou valor de HP:");
                    character.HP = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Introdueix el nou valor de MaxHP:");
                    character.MaxHP = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Introdueix el nou valor de Level:");
                    character.Level = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Introdueix el nou valor de Attack:");
                    character.Attack = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Introdueix el nou valor de Defense:");
                    character.Defense = Convert.ToUInt32(Console.ReadLine());
                }
            }
        }
    }
}