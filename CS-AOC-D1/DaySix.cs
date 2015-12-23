using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CS_AOC_D1
{
    /*
        --- Day 6: Probably a Fire Hazard ---

        Because your neighbors keep defeating you in the holiday house decorating contest year after year, you've decided to deploy one million lights in a 1000x1000 grid.

        Furthermore, because you've been especially nice this year, Santa has mailed you instructions on how to display the ideal lighting configuration.

        Lights in your grid are numbered from 0 to 999 in each direction; the lights at each corner are at 0,0, 0,999, 999,999, and 999,0. The instructions include whether to turn on, turn off, or toggle various inclusive ranges given as coordinate pairs. Each coordinate pair represents opposite corners of a rectangle, inclusive; a coordinate pair like 0,0 through 2,2 therefore refers to 9 lights in a 3x3 square. The lights all start turned off.

        To defeat your neighbors this year, all you have to do is set up your lights by doing the instructions Santa sent you in order.

        For example:

        turn on 0,0 through 999,999 would turn on (or leave on) every light.
        toggle 0,0 through 999,0 would toggle the first line of 1000 lights, turning off the ones that were on, and turning on the ones that were off.
        turn off 499,499 through 500,500 would turn off (or leave off) the middle four lights.
        After following the instructions, how many lights are lit?

        Your puzzle answer was 569999.

        --- Part Two ---

        You just finish implementing your winning light pattern when you realize you mistranslated Santa's message from Ancient Nordic Elvish.

        The light grid you bought actually has individual brightness controls; each light can have a brightness of zero or more. The lights all start at zero.

        The phrase turn on actually means that you should increase the brightness of those lights by 1.

        The phrase turn off actually means that you should decrease the brightness of those lights by 1, to a minimum of zero.

        The phrase toggle actually means that you should increase the brightness of those lights by 2.

        What is the total brightness of all lights combined after following Santa's instructions?

        For example:

        turn on 0,0 through 0,0 would increase the total brightness by 1.
        toggle 0,0 through 999,999 would increase the total brightness by 2000000.
        
    */
    public class DaySix
    {
        public static Dictionary<Point, Boolean> oLights = new Dictionary<Point, Boolean>();

        public static void daySix()
        {
            Console.WriteLine("");
            Console.WriteLine("Day Six");

            string wLine;
            System.IO.StreamReader wFile = new System.IO.StreamReader("DaySixData.txt");
            while ((wLine = wFile.ReadLine()) != null)
            {
                bool wTurnOn = wLine.StartsWith("turn on");
                bool wTurnOff = wLine.StartsWith("turn off");
                bool wToggle = wLine.StartsWith("toggle");

                wLine = wLine.Replace(" through ", ",").Replace("turn on ", "").Replace("turn off ","").Replace("toggle ", "");
                string[] wSplit = wLine.Split(',');
                if (wTurnOn)
                {
                    TurnOn(int.Parse(wSplit[0]), int.Parse(wSplit[2]), int.Parse(wSplit[1]), int.Parse(wSplit[3]));
                }
                else if (wTurnOff)
                {
                    TurnOff(int.Parse(wSplit[0]), int.Parse(wSplit[2]), int.Parse(wSplit[1]), int.Parse(wSplit[3]));
                }
                else if (wToggle)
                {
                    Toggle(int.Parse(wSplit[0]), int.Parse(wSplit[2]), int.Parse(wSplit[1]), int.Parse(wSplit[3]));
                }
            }


            int wTotal = oLights.Where(v => v.Value == true).Count();

            Console.WriteLine("Total lights on: " + wTotal);


            Console.ReadLine();
        }
        public static void TurnOn(int iXFrom, int iXTo, int iYFrom, int iYTo)
        {
            for (int wX = iXFrom; wX <= iXTo; wX++)
            {
                for (int wY = iYFrom; wY <= iYTo; wY++)
                {
                    Point wPt = new Point(wX, wY);
                    if (!oLights.ContainsKey(wPt))
                        oLights.Add(wPt, true);
                    else if (oLights.ContainsKey(wPt) && oLights[wPt] == false)
                        oLights[wPt] = true;
                }
            }
        }
        public static void Toggle(int iXFrom, int iXTo, int iYFrom, int iYTo)
        {
            for (int wX = iXFrom; wX <= iXTo; wX++)
            {
                for (int wY = iYFrom; wY <= iYTo; wY++)
                {
                    Point wPt = new Point(wX, wY);
                    if (!oLights.ContainsKey(wPt))
                        oLights.Add(wPt, true);
                    else if (oLights.ContainsKey(wPt) && oLights[wPt] == false)
                        oLights[wPt] = true;
                    else if (oLights.ContainsKey(wPt) && oLights[wPt] == true)
                        oLights[wPt] = false;
                }
            }
        }
        public static void TurnOff(int iXFrom, int iXTo, int iYFrom, int iYTo)
        {
            for (int wX = iXFrom; wX <= iXTo; wX++)
            {
                for (int wY = iYFrom; wY <= iYTo; wY++)
                {
                    Point wPt = new Point(wX, wY);
                    if (!oLights.ContainsKey(wPt))
                        oLights.Add(wPt, false);
                    else if (oLights.ContainsKey(wPt) && oLights[wPt] == true)
                        oLights[wPt] = false;
                }
            }
        }
    }
}
