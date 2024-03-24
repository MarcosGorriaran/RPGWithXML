using System;
using System.Xml.Linq;
using RPGWithXML;


namespace RPGWithXML
{
    class Program
    {
        static void Main()
        {
            const string Menu = "1. CREATE a new character" +
                "\n2. ADD new character" +
                "\n3. READ all the characters" +
                "\n4. UPDATE the character" +
                "\n5. COMBAT" +
                "\n6. Exit";
            const string MsgExit = "Exit the program";
            const string MsgCreateCharacter = "Create a new character:";
            const string MsgAddCharacter = "Add a new character to the XML file:";
            const string MsgReadCharacter = "Read the character from the XML file:";
            const string MsgUpdateCharacter = "Update the character:";
            const string AskSpecificName = "Enter the name of the character you want to update: ";
            const string AskFighterName = "Enter the name of the fighter: ";
            const string AskName = "Enter the name: ";
            const string AskLevel = "Enter the level: ";
            const string AskHealth = "Enter the health: ";
            const string AskAttack = "Enter the attack: ";
            const string AskDefense = "Enter the defense: ";

            string filePath = "../../../character.xml";
            string name, specificName, fighterNameOne, fighterNameTwo;
            uint level, attack, defense;
            int health, input;

            Console.WriteLine(Menu);
            input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1: //CREAR UN NUEVO PERSONAJE
                    Console.WriteLine(MsgCreateCharacter);

                    Console.Write(AskName);
                    name = Console.ReadLine();
                    Console.Write(AskLevel);
                    level = Convert.ToUInt16(Console.ReadLine());
                    Console.Write(AskHealth);
                    health = Convert.ToUInt16(Console.ReadLine());
                    Console.Write(AskAttack);
                    attack = Convert.ToUInt16(Console.ReadLine());
                    Console.Write(AskDefense);
                    defense = Convert.ToUInt16(Console.ReadLine());

                    XMLHelper.CreateXMLFile(filePath, name, level, health, attack, defense);

                    break;
                case 2: //AÑADIR UN NUEVO PERSONAJE AL ARCHIVO XML
                    Console.WriteLine(MsgAddCharacter);

                    Console.Write(AskName);
                    name = Console.ReadLine();
                    Console.Write(AskLevel);
                    level = Convert.ToUInt16(Console.ReadLine());
                    Console.Write(AskHealth);
                    health = Convert.ToUInt16(Console.ReadLine());
                    Console.Write(AskAttack);
                    attack = Convert.ToUInt16(Console.ReadLine());
                    Console.Write(AskDefense);
                    defense = Convert.ToUInt16(Console.ReadLine());

                    XMLHelper.AddCharacterToXMLFile(filePath, name, level, health, attack, defense);

                    break;
                case 3: //LEER EL PERSONAJE DESDE EL ARCHIVO XML
                    Console.WriteLine(MsgReadCharacter);

                    List<Character> characters = XMLHelper.ReadXMLFile(filePath);
                    XMLHelper.PrintResult(characters);

                    break;
                case 4: //ACTUALIZAR EL PERSONAJE EN EL ARCHIVO XML
                    Console.WriteLine(MsgUpdateCharacter);

                    Console.Write(AskSpecificName);
                    specificName = Console.ReadLine();

                    Console.WriteLine(AskName);
                    name = Console.ReadLine();
                    Console.Write(AskLevel);
                    level = Convert.ToUInt16(Console.ReadLine());
                    Console.Write(AskHealth);
                    health = Convert.ToUInt16(Console.ReadLine());
                    Console.Write(AskAttack);
                    attack = Convert.ToUInt16(Console.ReadLine());
                    Console.Write(AskDefense);
                    defense = Convert.ToUInt16(Console.ReadLine());

                    XMLHelper.UpdateXMLFile(filePath, specificName, name, level, health, attack, defense);

                    break;
                case 5: //COMBATE ENTRE DOS PERSONAJES
                    Console.WriteLine(AskFighterName);

                    Console.WriteLine(AskName);
                    fighterNameOne = Console.ReadLine();
                    Character playerOne = XMLHelper.SelectCharacter(filePath, fighterNameOne);

                    Console.WriteLine(AskName);
                    fighterNameTwo = Console.ReadLine();
                    Character playerTwo = XMLHelper.SelectCharacter(filePath, fighterNameTwo);

                    Combat.Fight(playerOne, playerTwo);

                    break;
                case 6:
                    Console.WriteLine(MsgExit);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}