using System;
using RPGWithXML;

namespace RPGWithXML

{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            using StreamReader sr = new StreamReader(path);
            string xml;
            List <Character> allCharacters = new List<Character>();
            while ((xml = sr.ReadLine()) != null)
            {
                Character character = xml.Deserialize<Character>();
                Console.WriteLine,($"Name: {character.Name}");
                Console.WriteLine($"Level: {character.Level}");
                Console.WriteLine($"Attack: {character.Attack}");
                Console.WriteLine($"Defense: {character.Defense}");
                allCharecters.Add(xml);
                
            }
        }
    }
}

