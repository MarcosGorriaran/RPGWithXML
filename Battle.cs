using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGWithXML
{
    public class Battle
    {
        public static uint AttackDamage(Character player, Character rival)
        {
            return player.Attack - rival.Defense;
        }
    }
}
