using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAloneLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            Random rand = new Random();
            int randomRoll = rand.Next(1, 101);
            System.Threading.Thread.Sleep(40);
            if (randomRoll <= attacker.CalcHitChance() - defender.CalcBlock())
            {
                int damageDealt = attacker.CalcDamage();

                defender.Life -= damageDealt;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} and was injured + ${ damageDealt}");
                Console.ResetColor();
            }//end if
            else
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }//end else
        }//end Attack()

        public static void DoFight(Player player, Villain villain)
        {
            DoAttack(player, villain);
            if (villain.Life > 0)
            {
                DoAttack(villain, player);
            }//end if
        }
    }
}
