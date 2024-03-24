using System;
using System.Xml.Linq;
using System.Xml.Serialization;
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
            const string MsgAttack = "{0} attacks {1}";
            const string MsgHealth = "{0} has {1} health left";
            const string Lines = "-----------------------------------------------------";
            const string XMLDocCreated = "XML document has been succesfully created.";
            const string XMLCharCreated = "New character has been added to the XML document.";
            const string XMLDocUpdated = "XML document has been succesfully created.";
            const string MsgWinner = " wins!";
            const string MsgInvalidOption = "Invalid option";
            const string FilePath = "../../../character.xml";
            const int CreateOption = 1;
            const int AddOption = 2;
            const int ReadOption = 3;
            const int UpdateOption = 4;
            const int CombatOption = 5;
            const int ExitOption = 6;

            string name, specificName, fighterNameOne, fighterNameTwo;
            uint level, attack, defense;
            int health, input;

            
            
            
            do
            {


                Console.WriteLine(Menu);
                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case CreateOption: //CREAR UN NUEVO PERSONAJE
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

                        XMLHelper.CreateXMLFile(FilePath, name, level, health, attack, defense);
                        Console.WriteLine(XMLDocCreated);
                        break;
                    case AddOption: //AÑADIR UN NUEVO PERSONAJE AL ARCHIVO XML
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

                        XMLHelper.AddCharacterToXMLFile(FilePath, name, level, health, attack, defense);
                        Console.WriteLine(XMLCharCreated);
                        break;
                    case ReadOption: //LEER EL PERSONAJE DESDE EL ARCHIVO XML
                        Console.WriteLine(MsgReadCharacter);

                        List<Character> characters = XMLHelper.ReadXMLFile(FilePath);
                        Console.Write(XMLHelper.PrintResult(characters));

                        break;
                    case UpdateOption: //ACTUALIZAR EL PERSONAJE EN EL ARCHIVO XML
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

                        XMLHelper.UpdateXMLFile(FilePath, specificName, name, level, health, attack, defense);
                        Console.WriteLine(XMLDocUpdated);
                        break;
                    case CombatOption: //COMBATE ENTRE DOS PERSONAJES
                        Console.WriteLine(AskFighterName);

                        Console.WriteLine(AskName);
                        fighterNameOne = Console.ReadLine();
                        Character playerOne = XMLHelper.SelectCharacter(FilePath, fighterNameOne);

                        Console.WriteLine(AskName);
                        fighterNameTwo = Console.ReadLine();
                        Character playerTwo = XMLHelper.SelectCharacter(FilePath, fighterNameTwo);

                        //simula una batalla hasta que la vida de uno queda 0
                        while (Character.AreCharsAlive(playerOne, playerTwo))
                        {
                            Console.WriteLine(MsgAttack, playerOne.Name, playerTwo.Name);
                            playerTwo.Health -= Convert.ToInt32(playerOne.Attack - playerTwo.Defense);
                            Console.WriteLine(MsgHealth, playerTwo.Name, playerTwo.Health);

                            Console.WriteLine(MsgAttack, playerTwo.Name, playerOne.Name);
                            playerOne.Health -= Convert.ToInt32(playerTwo.Attack - playerTwo.Defense);
                            Console.WriteLine(MsgHealth, playerOne.Name, playerOne.Health);

                            Console.WriteLine(Lines);
                        }

                        //Muestra el ganador
                        Console.WriteLine(playerOne.IsCharAlive() ? (playerOne.Name + MsgWinner) : (playerTwo.Name + MsgWinner));

                        break;
                    case ExitOption:
                        Console.WriteLine(MsgExit);
                        break;
                    default:
                        Console.WriteLine(MsgInvalidOption);
                        break;
                }
            } while (input != ExitOption);
        }
    }
}