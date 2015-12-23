using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CS_AOC_D1
{
    /*
        --- Day 4: The Ideal Stocking Stuffer ---

        Santa needs help mining some AdventCoins (very similar to bitcoins) to use as gifts for all the economically forward-thinking little girls and boys.

        To do this, he needs to find MD5 hashes which, in hexadecimal, start with at least five zeroes. The input to the MD5 hash is some secret key (your puzzle input, given below) followed by a number in decimal. To mine AdventCoins, you must find Santa the lowest positive number (no leading zeroes: 1, 2, 3, ...) that produces such a hash.

        For example:

        If your secret key is abcdef, the answer is 609043, because the MD5 hash of abcdef609043 starts with five zeroes (000001dbbfa...), and it is the lowest such number to do so.
        If your secret key is pqrstuv, the lowest number it combines with to make an MD5 hash starting with five zeroes is 1048970; that is, the MD5 hash of pqrstuv1048970 looks like 000006136ef....
        Your puzzle answer was 346386.

        --- Part Two ---

        Now find one that starts with six zeroes.

        Your puzzle answer was 9958218.
    */
    public class DayFour
    {
        public static void dayFour()
        {
            Console.WriteLine("");
            Console.WriteLine("Day Four");
            int wSolution = getSecretKey("iwrupvqb");
            Console.WriteLine("Solution is " + wSolution);
            Console.ReadLine();
        }
        public static int getSecretKey(String iKey)
        {
            int wAnswer = 0;
            bool wIsHashFound = false;
            while (!wIsHashFound)
            {
                wAnswer++;
                String wKeyToTest = generateKey(iKey, wAnswer);
                String wMD5Hash = calculateMD5Hash(wKeyToTest);
                if (wMD5Hash.StartsWith("00000"))
                {
                    wIsHashFound = true;
                }
            }
            return wAnswer;
        }

        public static string generateKey(string iKey, int iAnswer)
        {
            return String.Concat(iKey, iAnswer);
        }

        public static string calculateMD5Hash(string iInput)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(iInput);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
