using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_AOC_D1
{
    /*
        --- Day 5: Doesn't He Have Intern-Elves For This? ---

        Santa needs help figuring out which strings in his text file are naughty or nice.

        A nice string is one with all of the following properties:

        It contains at least three vowels (aeiou only), like aei, xazegov, or aeiouaeiouaeiou.
        It contains at least one letter that appears twice in a row, like xx, abcdde (dd), or aabbccdd (aa, bb, cc, or dd).
        It does not contain the strings ab, cd, pq, or xy, even if they are part of one of the other requirements.
        For example:

        ugknbfddgicrmopn is nice because it has at least three vowels (u...i...o...), a double letter (...dd...), and none of the disallowed substrings.
        aaa is nice because it has at least three vowels and a double letter, even though the letters used by different rules overlap.
        jchzalrnumimnmhp is naughty because it has no double letter.
        haegwjzuvuyypxyu is naughty because it contains the string xy.
        dvszwmarrgswjxmb is naughty because it contains only one vowel.
        How many strings are nice?

        Your puzzle answer was 236.

        --- Part Two ---

        Realizing the error of his ways, Santa has switched to a better model of determining whether a string is naughty or nice. None of the old rules apply, as they are all clearly ridiculous.

        Now, a nice string is one with all of the following properties:

        It contains a pair of any two letters that appears at least twice in the string without overlapping, like xyxy (xy) or aabcdefgaa (aa), but not like aaa (aa, but it overlaps).
        It contains at least one letter which repeats with exactly one letter between them, like xyx, abcdefeghi (efe), or even aaa.
        For example:

        qjhvhtzxzqqjkmpb is nice because is has a pair that appears twice (qj) and a letter that repeats with exactly one letter between them (zxz).
        xxyxx is nice because it has a pair that appears twice and a letter that repeats with one between, even though the letters used by each rule overlap.
        uurcxstgmygtbstg is naughty because it has a pair (tg) but no repeat with a single letter between them.
        ieodomkazucvgmuy is naughty because it has a repeating letter with one between (odo), but no pair that appears twice.
        How many strings are nice under these new rules?

        Your puzzle answer was 51.
    */
    public class DayFive
    {
        public static void dayFive()
        {
            Console.WriteLine("");
            Console.WriteLine("Day Five");

            int wCountOfGoodStrings = 0;
            int wCountOfGoodStringsPart2 = 0;

            string wLine;
            System.IO.StreamReader wFile = new System.IO.StreamReader("DayFiveData.txt");
            while ((wLine = wFile.ReadLine()) != null)
            {
                if (checkValidity(wLine))
                    wCountOfGoodStrings++;
                if (checkValidityPart2(wLine))
                    wCountOfGoodStringsPart2++;
            }

            Console.WriteLine("Solution is " + wCountOfGoodStrings);
            Console.WriteLine("Solution Part 2 is " + wCountOfGoodStringsPart2);
            Console.ReadLine();
        }

        #region Part1
        public static bool checkValidity(string iInput)
        {
            if (checkVowels(iInput) && checkDoubleLetters(iInput) && checkBadStrings(iInput))
                return true;
            return false;
        }

        public static bool checkVowels(string iInput)
        {
            HashSet<char> wVowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
            int wVowelCount = iInput.Count(c => wVowels.Contains(c));
            if (wVowelCount >= 3)
                return true;
            return false;
        }

        public static bool checkDoubleLetters(string iInput)
        {
            for (int wI = 0; wI < iInput.Length-1; wI++)
                if (iInput[wI] == iInput[wI + 1])
                    return true;
            return false;
        }
        public static bool checkBadStrings(string iInput)
        {
            string[] wInvalidStrings = new[] { "ab", "cd", "pq", "xy" };
            if (wInvalidStrings.Any(iInput.Contains))
                return false;
            return true;
        }
        #endregion

        #region Part2
        public static bool checkValidityPart2(string iInput)
        {
            if (checkPart2DoubleLetters(iInput) && checkPart2RepeatingLetterWithInbetween(iInput))
                return true;
            /* debug stuff
            if (checkPart2DoubleLetters(iInput) && !checkPart2RepeatingLetterWithInbetween(iInput))
                System.Diagnostics.Debug.WriteLine("{0} denied by rule aba", iInput, iInput);
            if (!checkPart2DoubleLetters(iInput) && checkPart2RepeatingLetterWithInbetween(iInput))
                System.Diagnostics.Debug.WriteLine("{0} denied by rule abab", iInput, iInput);
            if (!checkPart2DoubleLetters(iInput) && !checkPart2RepeatingLetterWithInbetween(iInput))
                System.Diagnostics.Debug.WriteLine("{0} denied by all rules", iInput, iInput);
            */
            return false;
        }

        public static bool checkPart2DoubleLetters(string iInput)
        {
            for (int wI = 0; wI < iInput.Length - 1; wI++)
            {
                if (iInput.IndexOf(String.Format("{0}{1}", iInput[wI], iInput[wI + 1]), wI + 2) > wI + 1) {
                    // Probably, another occurrence exists
                    return true;
                }
            }
            return false;
        }
        public static bool checkPart2RepeatingLetterWithInbetween(string iInput)
        {
            for (int wI = 0; wI < iInput.Length - 2; wI++) {
                if (iInput[wI].Equals(iInput[wI + 2]))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
