using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_AOC_D1
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Which day you want to run?");

            ConsoleKeyInfo wKey = Console.ReadKey();

            if (wKey.Key == ConsoleKey.NumPad1 || wKey.Key == ConsoleKey.D1)
            {
                DayOne.dayOne();
            }
            else if (wKey.Key == ConsoleKey.NumPad2 || wKey.Key == ConsoleKey.D2)
            {
                DayTwo.dayTwo();
            }
            else if (wKey.Key == ConsoleKey.NumPad3 || wKey.Key == ConsoleKey.D3)
            {
                DayThree.dayThree();
            }
            else if (wKey.Key == ConsoleKey.NumPad4 || wKey.Key == ConsoleKey.D4)
            {
                DayFour.dayFour();
            }
            else if (wKey.Key == ConsoleKey.NumPad5 || wKey.Key == ConsoleKey.D5)
            {
                DayFive.dayFive();
            }
            else if (wKey.Key == ConsoleKey.NumPad6 || wKey.Key == ConsoleKey.D6)
            {
                DaySix.daySix();
            }
            else
            {
                Console.WriteLine("Incorrect day. Sorry");
            }
        }




    }
}
