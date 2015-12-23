using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_AOC_D1
{
    /*
        --- Day 3: Perfectly Spherical Houses in a Vacuum ---

        Santa is delivering presents to an infinite two-dimensional grid of houses.

        He begins by delivering a present to the house at his starting location, and then an elf at the North Pole calls him via radio and tells him where to move next. Moves are always exactly one house to the north (^), south (v), east (>), or west (<). After each move, he delivers another present to the house at his new location.

        However, the elf back at the north pole has had a little too much eggnog, and so his directions are a little off, and Santa ends up visiting some houses more than once. How many houses receive at least one present?

        For example:

        > delivers presents to 2 houses: one at the starting location, and one to the east.
        ^>v< delivers presents to 4 houses in a square, including twice to the house at his starting/ending location.
        ^v^v^v^v^v delivers a bunch of presents to some very lucky children at only 2 houses.
        Your puzzle answer was 2081.

        --- Part Two ---

        The next year, to speed up the process, Santa creates a robot version of himself, Robo-Santa, to deliver presents with him.

        Santa and Robo-Santa start at the same location (delivering two presents to the same starting house), then take turns moving based on instructions from the elf, who is eggnoggedly reading from the same script as the previous year.

        This year, how many houses receive at least one present?

        For example:

        ^v delivers presents to 3 houses, because Santa goes north, and then Robo-Santa goes south.
        ^>v< now delivers presents to 3 houses, and Santa and Robo-Santa end up back where they started.
        ^v^v^v^v^v now delivers presents to 11 houses, with Santa going one direction and Robo-Santa going the other.
        Your puzzle answer was 2341.
    */
    public class DayThree
    {
        #region Day Three
        public static Point oCurrentHouse = new Point(0, 0);

        public static Point oCurrentHouseSanta = new Point(0, 0);
        public static Point oCurrentHouseRobot = new Point(0, 0);
        public const char moveUp = '^';
        public const char moveRight = '>';
        public const char moveDown = 'v';
        public const char moveLeft = '<';

        public static void dayThree()
        {
            Console.WriteLine("");
            Console.WriteLine("Day three");

            String wInput = "^><^>>>^<^v<v^^vv^><<^<><<vv^<>^<^v>^vv<>v><vv^^<>>^^^v<<vv><<^>^<^v<^>^v><<<v^<v<<<v<<vv<v<^><^>><>v>v^<<v^^<^v<><^>^<<^^^>v>>v^^<v>>^>vv><v>>^>>v^>^v>^<^^v>^>^^v<v>^^<v<>>v^^v><^><^<<>v^<^<^v<v>v^>>>v^v^>^<>^v<^^vv<v>^>^<>^^<vv^<><<v<^<^^>vv<>^>v<^>^v>v^>^v<>^><>><vv<>v^v<><>v^v>>>>v^^>^><^^<v<^><^<v>>^v^v<>v<<<^<<vvvv<<v^vv^>v^^^<^^^<v>>v<^v>>>>>v<^^^^>v<^<><v>>>>><v>>v^vvvv^^<v^<>^v<^v^>v><^>^v<<>>vv^>v>v^^>vv^<^vvv<>><>><><^^^<v<>^<^^^<v><^v>>v>^v<v^vv^<>^^^>v^^^v>>^v^^<^>>^>^<<v>>>^^<>>^vv>v^<^>>>><v<><><^^v<><<<<^^<>>^<vvv^><>v<v<<<<><v<<v>v<v^><vv<v^>^<^>v^^><^v>^^>v<>^v^<>^vv^><v^^vv>vvv>v>^<vv^>>^>>^>><>>>^^^^v<vv>^<>v^^><v^>^<>v<^^v><v<<><^v><>^^^^^v^v>>^^v><<><<vv>^^^^><^>v>><<<^v>v^^>^v^<^^v>v<^<<>>^v<<<v<<>>v<^v^><vv<v^v>v^<v>><v>^v<<<vv^>v<v>>v>>v><v><v^>v^^v>^v^>>>><>^>v>^v^>>>>v^<<vv<^v><<>v<v^<^^<<v<^v^^v^>vv><vv<v^<^>><^^>^<><^^<v<><^v^v^<^^>^<v><^<v>v^<<<^^v<v>^v>>><>^^>vv<<^v^<<<<^^>>>v>v<<<>^^>>>v>^>v>vv<<>^<^><v^>^^<^<v<<v<^>>^v^<vvv><>v^><<v>^^<v^vv^^^<vvv^<^>^>vv>><^v<^<<v<><<><<^^<><><vv>v>^<v>>^<>>^^v>vv^<^^v>><^vv^<<v^^><<>vv<v<><v<><v^^^v^v>^v<^<>v^^>><>^<^<v^<v^v^>v<<<^<<^>>>^^<^^v>v^<v>vvvv>v<>><^>^<<<<v^<v<>v^^^v<>v>^<v<<^^v^^<>^<<v^^<^<v>v>>v>>v^>^<vv<<<<<^<><>v><>>>v^>^v<^<><<v<^v^^<^<><^>^^^>^><>^><<vv>^<>vv<<v^v<<<<<>>>v<vv>^v>^>^>^<^><>v<><>>>^^<v>^<^v>>^<><v^><v^>>>v<v^^vvv^><v<v>v^>vvvv>>><^>v<>^^^>v>>v^<v<>v^>^<v^>^<<^>^>>v<<><<v^^>>v^<v^<^v^>^>v^><<^<v>v^<v>>^^<<v>v><<<^v^<>^<>^>>^<<v>^^<>^v<>v^>>><<v>><v^>^><v^<><v><>><v^<>vv>v^<^^^>v>^^<vv>>^v<><>>><>><^<>>v>v^^>^^<^^>^>>v>vv^^v<^<^v><vv<v<^>><<vvv<<><^>^v>^^^<<>v^<v<v><<v>^^v<<<>^^vv<^>vv>^>^<><<>vv<^>v^vv>^^^v><<^vv>^v<><v^^^^v^>vv^^<^<>^^v^<^vv<v<vv<>v>v^^<>^^>^^>^<><<^v>^><^^vvvv<><>^<v^^>v<>^><>v>><>vv^<<><<>><>v<^>^v>>^^v><<<>>^<^v^<v<<<v^>^^<^<><><^><<<<^<vv><v<<><vvv^^><vv>^<<vv<<<^v<>>><><>>v><<<v>vvvv^^vv<v>><<^v^vvv><><vv>v><>v<<<^<v^>><^^>v^<v>><v>^^^v^v>><<<v<^^>>^v<>v^<vv^^<<v<v>v<<<<^^^v^v<<>>>v>>vv>^^<><^v<v><>>v^>>>>>^>v^v^<^v^v^vvv>v<v<^>vv^<<v>vv>>v^^vv<^v>>>>vv<>v<>^^vv^<v>v^>>vvv<<<v<<^vv^^^^>v>v>^><<<^>v^><v<^<<<v>^v^^^><<><<<^^<^^<>^<v>^<v<<v<^^vv>v<^v><v><v<>^v<^<v<^<v^v><v>><v<v<<>^<v<>>><>^v^v<<^><v^<<v<v^>^>v><^>^vv^^<v<v<vv<v>^v^v^>^<<>>>>>v^<>^>v^vv^><<>>^^<>v^><v>^vvv^>v^v><>^><<>v>v<^<^><^^vv<<><>>v>>v><vv>>^v<<>^vv<>^vv>v>v>^>^>>><><<>v<v>^<<^v^^<<<><v>>vv<^<vv<vv^<<v<<^v><<>v<^^^<<^v^>^v>^^^v^v>>>v>v^v>^>^vv<^^<<vv^>^<<<vv>v^<><<^vvv^^><>vv^v>v>^><<^^^^vvv^<vvv>><^v<^>^<>>^<v<<vv>>><v>vv^<>><v^<v>^v>^>v>^<^<^^^<<vvvv^>>>>>>>v><vv>^<>^^v^><>><^v^^<v^v<<<<v^>><>v^v<vv<><^<<<<^>^^>vv>><^v<v^v<<>^vvv>v^^><^^<^<>>^^v^vv<>v<^<<<v^^^><v<vv<<>v>v<>^v^><v^vv^v^^v<^^v^^v><>v<^v>><<^<^v^>><<vv<<^>^<<v^<>^><>v><vv^v>>^<v<<<^>vv<^v>^>v<<v>^>>^>>v^<v<v>>^v<^v^v><<><>^><<<><v<vvvv<v^<v^v><>^<>^^^^v>^>^vvvvv>v>>v><<vv<<v<><<^><<^v><<v<<<v><vv<^>^v>>>>^v<^v<<>>^>^<<vv^<^>v>><<^>^>^v><><>^><<v<>v^><<^v^<^^><^^v^<<^v^^>>^v^<^><vv>v^^<<^^^<><>^>v^v>v^>^v^vv>^^>>>>^^<^>>>^^v<vv<><^^<vvv<^^^vv>v<v<v>><<<>^>^^>^>^v<<<<>>^<<>><v>>v>^^<^v<>v<>v^>v^><^<^^><v^^v>^^vv<v<<>><<vv<>>v>^<<<<v<<v>^><^^<^<^<v^<<^^v>^v<^>v^v^<v^vv^>^^><^>v^v>>^^v^><vv<v<v<v>>>>><<><v><v^v^<v^<^^<v<>^>v>v<>>>v>^^^^>><v^v^^v<<<>v^<<^<v>>>><^v^<<><v<>>v><><v<v^v>^v^^<v<^<^^v>><<vv<<vv><>>^>^>vv<^<>^vvv^v<v^^<>v^v>^^<<<<<>^v^>^<>v^^<>v^v<vv>^<>vv^<^vv>><v^^vvvvv>><<>v<vv^<^<vv^v^<>^^<v^<vv^<v^v^v<<^>^>^>^^>>>vvv>^>v>v>>>^>vv^><>^><>v>^^<v^>^><<v>><<<>>v<vvvv^>^v<^<>^<v>^<>^^<<><>^v<><>>>^vv<^<<^<^v>v<<<<<^^v<^v<><v<<><^>v>^v>>^v^><^^^^v<><><>vv^<>vv<^v<^^><v^<^><^^v^v^<^^<<><v>v<v<v^<<^v><>v^v<^>vvv><<^v>>v><><v<<^>>>v<^>>v>^<>><>^<v^v^<vv<<^>v<^^>^<^v<^<<^^v<>>^>^>^v^^v^v<v^^vv^<v>>v><vv^vv>v<>v^>v^^>^^>><v><v^<<><<>><<^^>><^v<v<><<><<><v<v^<^<v>>>><v^^v^^>>>^^^^^<<vv<^><>^<<<vv^^^>^><<<v<^v>^<v<^>^vvv<<>vv><<>v>v^v>>>>>^<>><^^^><<<<v><<vv>>>v<^<vv^v^<<v>>>>^^vvv>v<>><v>>>v>>^v^vvv<<>vvv<<^^^<>vv^^v<<>^^^>>^<^v^<^^>v^><v>>^<<^v<<vv<vv>v^>>^>v^><^><>^>>>vv>><^^^>vv<<^^vv><^<>^>^^<^<>>^vv^>>^v><>v^>>><<<^^<^>^>v<^>^<^^<>>><^^<>^v^<<vvv<v><>vvv><v>v^v<<^<v>^^><<^vv^v>v>v<<^v^<<<>^><><vvv>v>^vv^v<>vv^>^^<^>^>v^^<vv^>v><v<<<><>>^v<^<><><^<v^^<<^<v>vv<><<>v^<v^>^>^^<><<>^<^<<v^^v<v^<><<>v>><^<<>^>^v^v<v^v><^>>^v<^>v<<>^^^<^v>>>^<v>vvvv<<v^<^^>vvvv>v<>v<v><vvvvv>^<><>vvv<>^<<>^>>>>v^<^<><^v>v^>>v><>^><<v^>^<<>^>^v^<v^^>>^v><v>^<v><>v^<^^>v>^>>>v^v>>>^<>^<>>>>>v>>vv^v<><<<><><v><<vv<<v<><>>vv<^<vv>^v<<>v^v<^v<><v>>^v>>vvv^^v>>v>^>^>v><v><^>^^<<>^v<^<<<<^>v<^>>v^<^v>^v<<>^>^vvv<^^vv>^vv>vv<>>v>v<v>>v^<<<<<^^v^>v>^<<<v^v>>v<v><vvv><v>^<vv><<>>^<^>^^<>>>>^<^v<>v^^>^<^^v<^><>><v>>^v^vv<^v<^><<vvv<>><>><^^>^<^v^<^<>v<<<^v>v^^^<>v^<v^>^v^>><>^^<v<^><<^^v^<>^<^vv>>><^v><v^>vv<^v<<<v^>>v>v^v>^<v>v<^<>v^vvv>^vv<<<<v><^><v>>^^>><^v><<^>v^^<<v^^<^<><<<<>^<v<^v^>v<<^^>v<<<<<vvv<v<^>^>^>^>>^>>>v^<<v>>^^v><vv<^v<v<^^^>>>^vvv<^v<>>>vv>^^><^v>vv^>>v>v^<>^<vv>^>^<<^>^^^>>^vv>^^>vvvv<>>^^^^>>>v>v^^>vv>vv^<<>^><^<v^vvvv><v<><v>><<<v<v<<^v><vv^vv^<>>>^>^<v<^v<>><^<vv^^><v>v^>v^<><v^vvv>^>v^^v^>^^>v<<<<^<<^>>v>v^^^<<<v>>>^^v>v<v><<<<^^^v>^vv^>><>^v<v<<^^<<<<><>>>v>vvv^v^^v^>>vv>^>><>^v><^v^><^^>vv>^<^<^>><v>v>><><><v>^>^>v>vv>vv>^^>v>v^><v<<v^<>^>^v>^^v>^<^v<>>vvv^^>^>vv<v<v<<^<^<v^<>v^^v<^<^>vv^^<v><^^^>v>vv<<v>v<<v^<v^^><vv>^>^v^<^>v<^>^<>vv^><v<^><>>^>>^<^><<>^<^>v>v><>>>^<<^><<v><^v<v><>>vv<^><v^>>v>v>>>>^^>v<^v^>><<^<>>v><^><<^>^<vv^^<><<>><vvvv^>^^<><^^v>^^>vv>^v<v>>^^v^<v<^><^<<>>v^^^<^><^<<><<v<>><<>^v>vvv^vvv^^>>^<^<v>><>^<<<<^^<>>>v^<<^^v>><><<v<^>v>^v<v^>v>vv^><>^><<><^^>^>^<><>><^^<v^v<^><><><v>^<v<<v^<<^^^v<v<^v<>>><^v<<<<>>^v>^^vv^v^<<v>><<<v>vv>>v>>^v^<>>vv^<^>^<<>v<<<^vv<^vv^vv<^v^^^<vv^>v>>v<^^<^^vvv<^^v<>>>^>v^><v>^^><>vv>v>v<<<^^v<^vv^v>^^^>>>^^<>^^<^vvv>><><<><^<v>><<>^>^^<v^v^>vv>vv<v>^^<^^<<><><<v><v^^>v><v><<>v>vvv<^^^^<^>>><<<^^^<^>vv^^v>>v<<v^^<vv^<^>vvv^^v^^<^<vv>v<^<>^<<vv^^>^v>>^><><>v<v<v<>><v>>>^^>>v^><v^^<^>><>v<><<v^v<v<<>>>><>>>>><<^vvv<<><><<>^><><<^^v><<^>v>^>^v>v>>^^<><^>vv<^<^v>v<><^<<v<><^><>^^^<v^<><vvv^^^<>^^v><v<<<v>><>^>^vv<v^<vv>v>v^vv<v^v<v>^v^>v><>v^><>v>^^^^><<vv^><v<<v<^<>^v^^^>^^><<<v<^<v^>^^>v><vvvvv^<^<v^^>v<^v^^vv^<<<<v><^>v>v^v><><v^<<^<<v<^^^>^><v^v^<><><>^v<v>^<>^v>^v>v^<><^><v>>v<<^><^vv^<><^<>><>><v<v><<^^^^>v<^<^vv<><^vv><<^<<v>v^>>^v>^>v^^v>vv<v>v<<v>v<>^>>vv^>>><>^v^^<^>v<<^<^^v^^v^<<v<<v<^v<>vv^<v>><^v<^>>>vv^^<v^<>^^v<v<v>>^><^^^<><<^^>v<<vv>><<vvv>><<v^v^>><>vv^><<^>^><^v<^<^<vv<^^vv>v^v<<<<<<><<vv^vv>vv>v<^><<><><<>>v>><v><^>^v>^v^<>v^^^><^^<<<^vv^vv>^v^vvv^^>v^<v>><^<^<^<>^vv<vv^v^^>^^^>vv^v>>><<<^<>>v>v<^^<><v>>><><^v^^<<><<<>^<^^v^>v<vv^^^^>><v><^<<v<<v<>^>^>>^<>^v><>>^<v<vv^<<^<<>vv^>^^<<<^v<>>^v<>vvv<<^^<<><vvvvv<<^<^^<>>>>^^<><>^><>^v<v^^v<<v^^<^<^>v<v>^v<^>^v<>v^vv<><<v>^vvv<><<^>>^^><><>^<>^>v^^v^><v<><>>v><v^<v<<v>><^v>^<v<^>v<<<>vvv^<^^v<vvv^vv<>^<>^>>v<>^^><><v>>^><^^vv>><<>><v><^><>>^vv>v<vv<>v^v^^v<<^^<vv>v^^vv<<^<<><>^<><v^><^<^<>>^vv<v>v>>^<^vv>^vv^>v>^<><^><^<>v^v^^<^<>^^v>>><^v<>v^v<<^>v><>^^<<v^v<>v^>>v>^<><vv^v<v^<vv<>^>^>^<^>v><<><><><<<>^>><v^^><^>><v>>^v<<<^<<>^><<^>>>>>v<^>v>>v^<v^>^>v^^><>v^v^vvvv<v<v<>v>>><<>^<<vvv><v^v^>v<v^^^>>^<v>>^vv^^<vv><^>>v<v^><vvv<^^>>vv^v<^<>^v^<<v>^<<><<<^vvv^>^^<<>>><v<^>vv<<^<><^v<^<><<^^>vv^v>v^^^>>>>^>vv<<v>v>>^^v^^><>v<<^><^<v^>>^>v^v>><^v^>v<<^<v><^<^<^<>>v^^>><<<>v<v>v<^^>^vv<<<^^<v<>v^^>v<<><^<>^^>^v<>v>><^^^vv^>^><>v^^<v^<>>^<v^^^><v<><vvv>v>^<<^v>^>>>>><^^^<>v<v>>v^^<^v^>>v^<<v^>^>v^v>>>>^>>vv<>^<^v><v^^<>v>v^v>^<>^>v<vv><<v<^v<<^v<<^v^vv<><>^<>>^<>>^<>v^><<>^v>>^^^^<<^v><>^<^>^^v><^^<^<v^<^^v>^v><vv>v<<^>^>><<^^^vvv<<^vv<^^>v^^vv^<^^<<^^>>^^<vv<v<<v^^<<v<^vvv<<><<v>v^>>v^^>v<^>^><v<^>v<v^v<v^^<>v>><<v^v^v<^^^><v>v><^<^vv>^^v>^>v<<^vv><^^^^^^><<^>>>^v<>^^v<<<>><<<v^><>^<<<v>v^>^^^<^><v>^^^v<<>v<v>^<v^>><<^^<<^v<<>^v>>vv>><v<^><v<<<vvv><vv><<^v^^<v^vvv<^v>>v^v<v^v^>>^^v<><^^^<^^>v>^<><v<<v^^>vvv^v^^<v<v^v>^>v^^v<^><v^^<<<<>^^>>^v<><^><^<<^vv^<><<>v^vv^<v^<><<<^^>v<<>>>v<>v<><<<v>^v>^^v>^^>v>^>^>v<>><>^>^>^vvvv<^<v^<>^^^^v>v>><<v>>^<vv>>^<v<^v^vv>><>^^>v^^<<><^<v>><<<<>v>^^><v^^v<<v<><vv^v>^<v^^>v<<<<v^v<<>>vv<v<<<v>v>>v<^v>>v>v^<<<>^>^>^<>v<^^vv><^v<<^v<vvv^vv>v<^<<^^vv^^>vv<^>v>^^<<v^<<^^v<>^>v<<^^<^>^^^v^^<v<^<^>>>v^vv^<^v>^<>^<^<v<^v>>>^<^v<><v<^vv<v>v><v^v^^v<vv><^^<><>^>v<^<^vv>><^v><v<>^<>^^>^<><<<v^>>^<>><<><v>vvv^<<^<vv<v><v<^<<<^>^>>v<^>>vv>^v^^^v<>v<>><>^vv^>vv^";

            Dictionary<Point, int> wlArrayOfPresents = new Dictionary<Point, int>();
            Dictionary<Point, int> wlArrayOfPresentsY2 = new Dictionary<Point, int>();
            wlArrayOfPresents.Add(oCurrentHouse, 1);
            wlArrayOfPresentsY2.Add(oCurrentHouseSanta, 1);
            foreach (char wMove in wInput.ToCharArray())
            {
                move(wMove);
                deliverPresent(wlArrayOfPresents);
            }

            Console.WriteLine("Number of houses getting presents: " + wlArrayOfPresents.Count());
            Console.WriteLine("");
            Console.WriteLine("Day three - The next year");

            int i = 0;
            foreach (char wMove in wInput.ToCharArray())
            {
                if (isOdd(i))
                {
                    move(wMove, ref oCurrentHouseRobot);
                    deliverPresent(wlArrayOfPresentsY2, oCurrentHouseRobot);
                }
                else
                {
                    move(wMove,ref oCurrentHouseSanta);
                    deliverPresent(wlArrayOfPresentsY2, oCurrentHouseSanta);
                }
                i++;
            }
            Console.WriteLine("Number of houses getting presents Y2: " + wlArrayOfPresentsY2.Count());

            Console.ReadLine();
        }
        public static bool isOdd(int iValue)
        {
            return iValue % 2 != 0;
        }
        public static void deliverPresent(Dictionary<Point, int> ilArrayOfPresents)
        {
            deliverPresent(ilArrayOfPresents, oCurrentHouse);
        }
        public static void deliverPresent(Dictionary<Point, int> ilArrayOfPresents, Point iCurrentHouse)
        {
            if (ilArrayOfPresents.ContainsKey(iCurrentHouse))
                ilArrayOfPresents[iCurrentHouse]++;
            else
                ilArrayOfPresents.Add(iCurrentHouse, 1);
        }
        public static void move(char iMove)
        {
            move(iMove, ref oCurrentHouse);
        }
        public static void move(char iMove, ref Point iCurrentHouse)
        {
            switch (iMove)
            {
                case moveUp:
                    iCurrentHouse.X = iCurrentHouse.X + 1;
                    break;
                case moveLeft:
                    iCurrentHouse.Y = iCurrentHouse.Y - 1;
                    break;
                case moveDown:
                    iCurrentHouse.X = iCurrentHouse.X - 1;
                    break;
                case moveRight:
                    iCurrentHouse.Y = iCurrentHouse.Y + 1;
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
