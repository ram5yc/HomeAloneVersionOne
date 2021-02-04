using HomeAloneLibrary;
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

            int score = 0;

            bool exit = false;
            do
            {
                Villain harry = new Villain("Harry", 40, 10, 15, 5, 30, "One of the two Wet Bandits! Lookout, he will try and grab you!", 5);

                Villain marv = new Villain("Marv", 20, 50, 5, 10, 20, "He is tall and quick, be careful or you will slip!", 2);

                Villain concierge = new Villain("The Concierge", 45, 50, 60, 10, 20, "Beware! He,is sneaky and nice but he will catch you if you think twice!", 10);

                Villain[] villains =
                {
                    concierge, concierge, marv, marv, marv, harry, harry, harry, harry
                };

                Villain villain = villains[new Random().Next(villains.Length)]; //makes villain choice random
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{villain.Name} is in this room. Collect the required items and exit before he catches you!");
                Console.ResetColor();

                bool reloadAdventure = false;
                do
                {
                    Console.Write(
                        "A)Player Stats\n" +
                        "B)Villain Stats" +
                        "C)Weapon" +
                        "D)Choose Location");
                    ConsoleKey userChoice =
                    Console.ReadKey().Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Console.WriteLine(player);
                            break;

                        case ConsoleKey.B:
                            Console.WriteLine(villain);
                            break;

                        case ConsoleKey.C:
                            break;

                        case ConsoleKey.D:
                            break;

                        default:
                            Console.WriteLine(userChoice + "You’re what the French call, ‘les incompétents'!...Try again.");
                            break;
                    }

                } while (!reloadAdventure && !exit);

            } while (!exit);
            Console.WriteLine($"You have gather {} itemes.");
            Console.WriteLine("You are no longer Home Alone. Thanks for playing!");
        }//end Main()

        private static string GetAdventure()
        {
            Location location1 = new Location("Here you find Harry and Marv in the next aisle over, choose weapon to get away from the crooks!", "Grocery Store", 2);
            Location location2 = new Location("You enter the basement where you see the scary heater and hear the slow creaking of the floor boards.Harry and Marv enter the house slowly, waiting for the next booby trap to appear.", "Basement", 5);
            Location location3 = new Location("Kev will have to face Harry who has left Marv behind.", "Church", 1);
            Location location4 = new Location("You can recharge but it's a dangerous, booby - trapped laced place! WATCH OUT!", "Home", 0);

            Console.WriteLine(location1);
            Console.WriteLine(location2);
            Console.WriteLine(location3);
            Console.WriteLine(location4);
        }

    }
}
