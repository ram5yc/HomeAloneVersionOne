using HomeAloneLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeAloneApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Home Alone: Trapped in an App";


            Console.ForegroundColor = ConsoleColor.Red;
            var myString = "Oh No! You have found that your parents left you Home Alone!\n";
            foreach (var character in myString)
            {
                Console.Write(character);
                Thread.Sleep(30);
            }
            Console.WriteLine();


            var mySecondString = "They are heading to France for the holidays so you have to earn points to stay safe from the crooks!\n";

            foreach (var character in mySecondString)
            {
                Console.Write(character);
                Thread.Sleep(30);

            }


            int score = 0;

            Player player = new Player("Kevin McCallister", 50, 50, new Weapon(15, 5, "BB Gun"), 15, 5, 80, 30);

            Location userLocation = GetAdventure();

            bool exit = false;

            do
            {
                Weapon rope = new Weapon(10, 2, "Marv's Rope");
                Weapon marbles = new Weapon(15, 5, "Toe-breaking Marbles");
                Weapon shovel = new Weapon(20, 10, "Shovel");

                Weapon[] weapons =
                {
                    rope, rope, rope, marbles, marbles, shovel
                };

                Weapon weapon = weapons[new Random().Next(weapons.Length)];

                Villain harry = new Villain("Harry", 40, 10, 15, 5, 30, 20, "One of the two Wet Bandits! Lookout, he will try and grab you!", 10, 40, 30, rope);

                Villain marv = new Villain("Marv", 20, 50, 25, 10, 20, 15, "He is tall and quick, be careful or you will slip!", 10, 50, 40, shovel);

                Villain concierge = new Villain("The Concierge", 45, 50, 60, 10, 20, 15, "Beware! He,is sneaky and nice but he will catch you if you think twice!", 10, 60, 50, marbles);

                Villain[] villains =
                {
                    concierge, concierge, marv, marv, marv, harry, harry, harry, harry
                };

                Villain villain = villains[new Random().Next(villains.Length)]; //makes villain choice random
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{villain.Name} sees you! Attack (A) {villain.Name} to acquire items.\n");
                Console.ResetColor();





                //do
                //{
                //    Console.WriteLine("Click P to pick up items.\n");
                //    switch (switch_on)
                //    {
                //        default:
                //    }
                //} while;

                bool reloadAdventure = false;
                do
                {
                    Console.Write("Choose an action:\n" +
                        "P) Player Stats\n" +
                        "V) Villain Stats\n" +
                        "W) Weapon\n" +
                        "A) Attack\n" +
                        "F) Flee\n" +
                        "\nPress Esc to exit game\n");
                    ConsoleKey userChoice =
                    Console.ReadKey().Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.P:
                            Console.WriteLine(player);
                            break;

                        case ConsoleKey.V:
                            Console.WriteLine(villain);
                            break;

                        case ConsoleKey.W:
                            Console.WriteLine(weapon);
                            break;

                        case ConsoleKey.A:
                            bool keepBattling = true;
                            do
                            {
                                Combat.DoFight(player, villain);
                                if (villain.Life <= 0)
                                {
                                    Console.WriteLine($"\nYou killed\n {villain.Name}!");
                                    score++;
                                    player.Items += userLocation.Items;
                                    keepBattling = false;
                                    reloadAdventure = true;
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Do you want to keep battling? Y/N");
                                string userAnswer = Console.ReadLine().ToUpper();
                                if (userAnswer == "N")
                                {
                                    keepBattling = false;
                                }
                            } while (keepBattling == true);
                            Console.Clear();
                            break;

                        case ConsoleKey.F:
                            Console.WriteLine($"{villain.Name} attacks you as you flee!");
                            Combat.DoAttack(villain, player);
                            reloadAdventure = true;
                            break;

                        case ConsoleKey.Escape:
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            var christmasTree = "\nYou are what the French call, ‘les incompétents'!";
                            foreach (var character in christmasTree)
                            {
                                Console.Write(character);
                                Thread.Sleep(80);
                            }
                    
                            Console.WriteLine(@"
            
                                          /\
                                         <  >
                                          \/
                                          /\
                                         /  \
                                        / ++++\
                                        / ()  \
                                       /      \
                                      / ~`~`~`~`\
                                      /  ()()  \
                                     /          \
                                    /*&*&*&*&*&*&\
                                   /  ()  ()  ()  \
                                   /              \
                                  /++++++++++++++++\
                                 /  ()  ()  ()  ()  \
                                 /                  \
                                /~`~`~`~`~`~`~`~`~`~`\
                               /  ()  ()  ()  ()  ()  \
                               /*&*&*&*&*&*&*&*&*&*&*&\
                              /                        \
                             /,.,.,.,.,.,.,.,.,.,.,.,.,.\
                                        |   |
                                       |`````|
                                       \_____/
          _____________________CLICK ENTER TO CONTINUE_____________________");
                          


                            Console.ReadLine();
                            Console.ResetColor();
                            Console.Clear();

                            exit = true;
                            break;

                        default:
                            Console.WriteLine(userChoice + "Invalid choice!...Try again.");
                            break;
                    }
                    if (player.Life <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        var christmasTree = "\nThe crooks have won...MERRY CHRISTMAS, YA FILTHY ANIMAL...";
                        foreach (var character in christmasTree)
                        {
                            Console.Write(character);
                            Thread.Sleep(80);
                        }
                        Console.WriteLine(@"
            
                                          /\
                                         <  >
                                          \/
                                          /\
                                         /  \
                                        / ++++\
                                        / ()  \
                                       /      \
                                      / ~`~`~`~`\
                                      /  ()()  \
                                     /          \
                                    /*&*&*&*&*&*&\
                                   /  ()  ()  ()  \
                                   /              \
                                  /++++++++++++++++\
                                 /  ()  ()  ()  ()  \
                                 /                  \
                                /~`~`~`~`~`~`~`~`~`~`\
                               /  ()  ()  ()  ()  ()  \
                               /*&*&*&*&*&*&*&*&*&*&*&\
                              /                        \
                             /,.,.,.,.,.,.,.,.,.,.,.,.,.\
                                        |   |
                                       |`````|
                                       \_____/
          _____________________CLICK ENTER TO CONTINUE_____________________");


                        Console.ReadLine();
                        Console.ResetColor();
                        Console.Clear();
               
                        exit = true;


                    }
              
                } while (!reloadAdventure && !exit);
                
            } while (!exit);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You have gathered {score} marbles. Have a Merry Christmas\n");
            Console.Clear();
        }//end Main()

        private static Location GetAdventure()
        {

            Location location = new Location();

            bool keepRunning = true;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write("\nChoose a location to begin...\n" +
                "A) Grocery Store\n" +
                "B) Basement\n" +
                "C) Church\n" +
                "D) Home\n");

                ConsoleKey userAnswer =
                Console.ReadKey().Key;
                Console.Clear();
                //string userAnswer = Console.ReadLine().ToUpper();
                switch (userAnswer)
                {

                    case ConsoleKey.A:
                        Thread.Sleep(40);
                        location = new Location("You are on a shopping spree but you see the crooks in the next aisle over.\n", "Grocery Store", 2);
                        Console.WriteLine(location);
                        keepRunning = false;
                        break;
                    case ConsoleKey.B:
                        Thread.Sleep(40);
                        location = new Location("You enter the basement. At the far corner you see the heater come ALIVE! All of a sudden, you hear the slow creaking of the floor boards...\n", "Basement", 5);
                        Console.WriteLine(location);
                        keepRunning = false;
                        break;
                    case ConsoleKey.C:
                        Thread.Sleep(40);
                        location = new Location("This may be a safe place but be alert, someone may try to catch you!\n", "Church", 1);
                        Console.WriteLine(location);
                        keepRunning = false;
                        break;
                    case ConsoleKey.D:
                        Thread.Sleep(40);
                        location = new Location("You can recharge here but it's a dangerous, booby - trapped laced place! WATCH OUT!\n", "Home", 0);
                        Console.WriteLine(location);
                        keepRunning = false;
                        break;

                    default:
                        Thread.Sleep(40);
                        Console.WriteLine("Incorrect Choice. Please try again!\n");
                        break;
                }
            } while (keepRunning);

            return location;

        }//end SecondMi
    }//end Class
}//end NameSpace

