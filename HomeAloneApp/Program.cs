using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAloneApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Oh No! You have found that your parents left you home alone! They are heading to France for the holidays so you have to earn points to stay safe from the crooks!");

            Console.Title = "Home Alone: Trapped in an App";

            int score = 0
            bool exit = false;
            do
            {
                Villain harry = new Villain(5, "Harry", "Rope", 40, 10, "Jump", DroppedItem.Name);

                Villain marv = new Villain(10, "Marv", "Bucket of Water", 50, 5, "Jump", DroppedItem.Name);

                Villain concierge = new Villain(15, "The Concierge", "Key to a door", 60, 15, "Jump", DroppedItem.Name);

                Villain[] villains =
                {
                    concierge, concierge, marv, marv, marv, harry, harry, harry, harry
                };

                Villain villain = villains[new Random().Next(villains.Length)]; //makes villain choice random

            } while (!exit);
        }
    }
}
