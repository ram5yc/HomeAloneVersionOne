using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAloneLibrary
{
    public class Character
    {
        private int _life;

        public string Name { get; set; }
        public int Speed { get; set; }
        public int MaxLife { get; set; }
        public int MinLife { get; set; }
        public int HitChance { get; set; }
        public int Block { get; set; }
        public Weapon Weapon { get; set; }


        public int Life
        {
            get { return _life; }
            set
            {
                _life = value <= MaxLife ? value : MaxLife;
            }
        }
        public Character(string name, int speed, int life, int maxLife, int minLife, int hitChance, int block, Weapon weapon)
        {

            Name = name;
            Speed = speed;
            MaxLife = maxLife;
            Life = life;
            MinLife = minLife;
            HitChance = hitChance;
            Block = block;
            Weapon = weapon;
       

        }
        public virtual int CalcBlock()
        {
            return Block;
        }
        public virtual int CalcDamage()
        {
            return 0;
        }
        public virtual int CalcHitChance()
        {
            return HitChance;
        }
      
    }
}
