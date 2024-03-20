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
                Console.WriteLine(character.ToString());
                Console.WriteLine("Para cambiar estas caracteristicas pulsa 1, para seguir pulsa cualquier otra tecla");
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("Introduce el nuevo nombre");
                    character.Name = Console.ReadLine();
                    Console.WriteLine("Introduce el nuevo nivel");
                    character.Level = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Introduce el nuevo ataque");
                    character.Attack = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Introduce la nueva defensa");
                    character.Defense = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Introduce la nueva vida");
                    character.MaxHP = Convert.ToUInt32(Console.ReadLine());
                }
                allCharacters.Add(character);
                
            }
            using StreamWriter sw = new StreamWriter(path)
            {
                foreach (Character character in allCharacters)
                {
                    sw.WriteLine(character.Serialize());
                }
            }
        }
    }
}

