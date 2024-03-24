using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RPGWithXML
{
    public class Combat
    {
        public static void Fight(Character firstPlayer, Character secondPlayer)
        {
            const string MsgAttack = "{0} attacks {1}";
            const string MsgHealth = "{0} has {1} health left";
            const string Lines = "-----------------------------------------------------";
            const string MsgWinner = " wins!";
            
            //simula una batalla hasta que la vida de uno queda 0
            while (firstPlayer.Health > 0 && secondPlayer.Health > 0)
            {
                Console.WriteLine(MsgAttack, firstPlayer.Name, secondPlayer.Name);
                secondPlayer.Health -= Convert.ToInt32(firstPlayer.Attack - secondPlayer.Defense);
                Console.WriteLine(MsgHealth, secondPlayer.Name, secondPlayer.Health);

                Console.WriteLine(MsgAttack, secondPlayer.Name, firstPlayer.Name);
                firstPlayer.Health -= Convert.ToInt32(secondPlayer.Attack - firstPlayer.Defense);
                Console.WriteLine(MsgHealth, firstPlayer.Name, firstPlayer.Health);

                Console.WriteLine(Lines);
            }

            //Muestra el ganador
            Console.WriteLine(firstPlayer.Health > 0 ? (firstPlayer.Name + MsgWinner) : (secondPlayer.Name + MsgWinner));
        }
    }
}
