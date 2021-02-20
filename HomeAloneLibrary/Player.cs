using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAloneLibrary
{
    public class Player : Character
    {

        public Weapon Weapon { get; set; }
        public int Items { get; set; }

        public Player(string name, int life, int speed, Weapon weapon, int maxLife, int minLife, int hitChance, int block) : base(name, speed, life, maxLife, minLife, hitChance, block)
        {
            Weapon = weapon;
            Items = 0;

        }//FQCTOR
        public override string ToString()
        {
            return string.Format("{0}\nLife: {1}\nSpeed: {2}\nMaxLife: {3}\nMinLife: {4}\nWeapon: {5}\nItems Collected: {6}",
                Name,
                Life,
                Speed,
                MaxLife,
                MinLife,
                Weapon,
                Items);
        }
        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(Weapon.MinDamage, Weapon.MaxDamage + 1);

            return damage;
        }
        public override int CalcHitChance()
        {
            return CalcHitChance();
        }//end CalcHitChance()
    }
}
