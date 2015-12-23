using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_AOC_D1
{
    /*
        --- Day 2: I Was Told There Would Be No Math ---

        The elves are running low on wrapping paper, and so they need to submit an order for more. They have a list of the dimensions (length l, width w, and height h) of each present, and only want to order exactly as much as they need.

        Fortunately, every present is a box (a perfect right rectangular prism), which makes calculating the required wrapping paper for each gift a little easier: find the surface area of the box, which is 2*l*w + 2*w*h + 2*h*l. The elves also need a little extra paper for each present: the area of the smallest side.

        For example:

        A present with dimensions 2x3x4 requires 2*6 + 2*12 + 2*8 = 52 square feet of wrapping paper plus 6 square feet of slack, for a total of 58 square feet.
        A present with dimensions 1x1x10 requires 2*1 + 2*10 + 2*10 = 42 square feet of wrapping paper plus 1 square foot of slack, for a total of 43 square feet.
        All numbers in the elves' list are in feet. How many total square feet of wrapping paper should they order?

        Your puzzle answer was 1586300.

        --- Part Two ---

        The elves are also running low on ribbon. Ribbon is all the same width, so they only have to worry about the length they need to order, which they would again like to be exact.

        The ribbon required to wrap a present is the shortest distance around its sides, or the smallest perimeter of any one face. Each present also requires a bow made out of ribbon as well; the feet of ribbon required for the perfect bow is equal to the cubic feet of volume of the present. Don't ask how they tie the bow, though; they'll never tell.

        For example:

        A present with dimensions 2x3x4 requires 2+2+3+3 = 10 feet of ribbon to wrap the present plus 2*3*4 = 24 feet of ribbon for the bow, for a total of 34 feet.
        A present with dimensions 1x1x10 requires 1+1+1+1 = 4 feet of ribbon to wrap the present plus 1*1*10 = 10 feet of ribbon for the bow, for a total of 14 feet.
        How many total feet of ribbon should they order?

        Your puzzle answer was 3737498.
    */
    public class DayTwo
    {
        #region Day Two
        public static void dayTwo()
        {
            int wTotalPaperSurface = 0;
            int wTotalRibbonLength = 0;

            string wLine;
            System.IO.StreamReader wFile = new System.IO.StreamReader("daytwodata.txt");
            while ((wLine = wFile.ReadLine()) != null)
            {
                String[] wSides = wLine.Split('x');
                int wSurface = getPresentSurface(int.Parse(wSides[0]), int.Parse(wSides[1]), int.Parse(wSides[2]));
                int wLength = getRibbonLength(int.Parse(wSides[0]), int.Parse(wSides[1]), int.Parse(wSides[2]));
                wTotalPaperSurface += wSurface;
                wTotalRibbonLength += wLength;
            }

            Console.WriteLine("Total Paper Surface : " + wTotalPaperSurface + " Square Feet");
            Console.WriteLine("Total Ribbon Length : " + wTotalRibbonLength + " Feet");
            Console.ReadLine();
        }
        public static int getPresentSurface(int iLength, int iWidth, int iHeight)
        {
            int wSideOne = getSideOneSize(iLength, iWidth);
            int wSideTwo = getSideTwoSize(iWidth, iHeight);
            int wSideThree = getSideThreeSize(iHeight, iLength);

            List<int> wSides = new List<int>() { wSideOne, wSideTwo, wSideThree };
            int wBoxSurface = getBoxSurface(wSides);
            int wExtraSurface = getSmallestSide(wSides);

            int wTotalPaperSize = wBoxSurface + (wExtraSurface / 2);
            return wTotalPaperSize;
        }
        public static int getRibbonLength(int iLength, int iWidth, int iHeight)
        {
            int wRibbonLength = 0;
            // get Sum of smallest sides
            int wSmallestSidesLength = getSmallestSidesLength(new List<int>() { iLength, iWidth, iHeight });

            // get length of bow
            int wVolume = getBoxVolume(iLength, iWidth, iHeight);

            wRibbonLength = wVolume + wSmallestSidesLength;

            return wRibbonLength;
        }
        public static int getSmallestSidesLength(List<int> iSides)
        {
            iSides.Sort();
            int wLength = 0;
            wLength += (iSides.First() * 2);
            wLength += (iSides.ElementAt(1) * 2);
            return wLength;
        }

        public static int getBoxVolume(int iLength, int iWidth, int iHeight)
        {
            return iLength * iWidth * iHeight;
        }
        public static int getSideOneSize(int iLength, int iWidth)
        {
            return (2 * iLength * iWidth);
        }
        public static int getSideTwoSize(int iWidth, int iHeight)
        {
            return (2 * iWidth * iHeight);
        }
        public static int getSideThreeSize(int iHeight, int iLength)
        {
            return (2 * iHeight * iLength);
        }
        public static int getSmallestSide(List<int> iSides)
        {
            iSides.Sort();
            return (int)(iSides.First());
        }
        public static int getBoxSurface(List<int> iSides)
        {
            int wSurface = 0;
            foreach (int wInt in iSides)
                wSurface += wInt;
            return wSurface;
        }
        #endregion
    }
}
