using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAloneLibrary
{
    public class Villain : Character
    {
        private int _minDamage;
        private List<Weapon> _equippedWeapon;

        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1; //says damage is greater than 0 and is less than max damage or 1
            }//end set
        }//end MinDamage
        public Weapon Weapon { get; set; }

        public Villain(string name, int speed, int life, int maxLife, int minLife, int hitchance, int maxDamage, string description, int minDamage, int hitChance, int block) : base(name, speed, life, maxLife, minLife, hitChance, block)
        {
            MaxDamage = maxDamage;
            MinDamage = MinDamage;
            Description = description;
           
        }
        public virtual int CalcBlock()
        {
            return Block;
        }
 

        public override string ToString()
        {
            return string.Format($"{Name}\n{Description}\nLife Remaining: {Life}");
        }

    }
}
