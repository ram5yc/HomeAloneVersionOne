using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAloneLibrary
{
    public class Weapon
    {
        private int _minDamage;
        public int MaxDamage { get; set; }
        public string Name { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }//end set
        }//end MinDamage

        public Weapon(int minDamage, int maxDamage, string name)
        {
            MaxDamage = maxDamage;
            Name = name;
            MinDamage = minDamage;
        }
        public override string ToString()
        {
            return string.Format("{0}\n{1} to {2} damage",
                Name,
                MaxDamage,
                MinDamage);
        }//end ToString()
    }
}
