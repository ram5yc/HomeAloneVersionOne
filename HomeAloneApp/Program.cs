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

            Console.WriteLine("Oh No! You have found that your parents left you Home Alone! They are heading to France for the holidays so you have to earn points to stay safe from the crooks!");

            Console.Title = "Home Alone: Trapped in an App";

            int score = 0;

            Player player = new Player("Kevin McCallister", 50, 50, new Weapon(15, 5, "BB Gun"), 15, 5, 30, 20);

            bool exit = false;
            do
            {
                Location userLocation = GetAdventure(); 

                Villain harry = new Villain("Harry", 40, 10, 15, 5, 30, 20, "One of the two Wet Bandits! Lookout, he will try and grab you!", 10, 10, 30);

                Villain marv = new Villain("Marv", 20, 50, 25, 10, 20, 15, "He is tall and quick, be careful or you will slip!", 10, 25, 15);

                Villain concierge = new Villain("The Concierge", 45, 50, 60, 10, 20, 15, "Beware! He,is sneaky and nice but he will catch you if you think twice!", 10, 15, 30);

                Villain[] villains =
                {
                    concierge, concierge, marv, marv, marv, harry, harry, harry, harry
                };

                Villain villain = villains[new Random().Next(villains.Length)]; //makes villain choice random
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{villain.Name} sees you! Collect the required items and exit before he catches you!");
                Console.ResetColor();

                Weapon rope = new Weapon(10, 2, "Marv's Rope");
                Weapon marbles = new Weapon(15, 5, "Toe-breaking Marbles");
                Weapon shovel = new Weapon(20, 10, "Shovel");

                Weapon[] weapons =
                {
                    rope, rope, rope, marbles, marbles, shovel
                };

                Weapon weapon = weapons[new Random().Next(weapons.Length)];
                Console.WriteLine($"You were attacked with the {weapons}. Try and gather the weapon from the villain by attacking him.");

                bool reloadAdventure = false;
                do
                {
                    Console.Write("Choose an action:\n" +
                        "A)Player Stats\n" +
                        "B)Villain Stats\n" +
                        "C)Weapon\n" +
                        "P)Pick up items\n" +
                        "E)Attack\n" +
                        "F)Flee\n" +
                        "Press Esc to exit game\n");
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
                            Console.WriteLine(weapon);
                            break;

                        case ConsoleKey.D:
                            Console.WriteLine(userLocation + userLocation.Description);
                            break;

                        case ConsoleKey.E:
                            Combat.DoFight(player, villain);
                            if (villain.Life <= 0)
                            {
                                Console.WriteLine($"\nYou killed\n {villain.Name}!");
                                score++;
                                player.Items += userLocation.Items;
                                reloadAdventure = true;
                            }
                            break;

                        case ConsoleKey.F:
                            Console.WriteLine("You are fleeing the adventure! Make sure you have enough items to leave!");
                            Console.WriteLine($"{villain.Name} tricks you as you flee!");
                            Combat.DoAttack(villain, player);
                            reloadAdventure = true;
                            break;

                        case ConsoleKey.Escape:
                            Console.WriteLine(userChoice + " You’re what the French call, ‘les incompétents'!");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine(userChoice + "Invalid choice!...Try again.");
                            break;
                    }
                    if (player.Life <= 0)
                    {
                        Console.WriteLine("Harry, Marv, and the concierge have won! I hope your parents can save you!");
                        exit = true;
                    }

                } while (!reloadAdventure && !exit);

            } while (!exit);
            Console.WriteLine($"You have to gather {score} items.");
            Console.WriteLine("You are no longer Home Alone. Thanks for playing!");
        }//end Main()

        private static Location GetAdventure()
        {
            
            Location location = new Location();

            bool keepRunning = true;
            do
            {
                Console.Write("Choose a location to begin the game...\n" +
                "A) Grocery Store\n" +
                "B) Basement\n" +
                "C) Church\n" +
                "D) Home");

                ConsoleKey userAnswer =
                Console.ReadKey().Key;
                Console.Clear();
                //string userAnswer = Console.ReadLine().ToUpper();

                switch (userAnswer)
                {
                    case ConsoleKey.A:
                        location = new Location("You find Harry and Marv in the next aisle over. Hurry and leave the grocery store before they see you.", "Grocery Store", 2);
                        Console.WriteLine(location);
                        keepRunning = false;
                        break;
                    case ConsoleKey.B:
                        location = new Location("You enter the basement where you see the scary heater and hear the slow creaking of the floor boards. Harry and Marv enter the house slowly, waiting for the next booby trap to appear.", "Basement", 5);
                        Console.WriteLine(location);
                        keepRunning = false;
                        break;
                    case ConsoleKey.C:
                        location = new Location("This may be a Holy Place but Harry is ready to catch you!", "Church", 1);
                        Console.WriteLine(location);
                        keepRunning = false;
                        break;
                    case ConsoleKey.D:
                        location = new Location("You can recharge here but it's a dangerous, booby - trapped laced place! WATCH OUT!", "Home", 0);
                        Console.WriteLine(location);
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please try again!");
                        break;
                }
            } while (keepRunning);

            return location;

        }

    }
}
