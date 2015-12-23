using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_AOC_D1;
using System.Windows;

namespace TestProjectAOC
{
    [TestClass]
    public class TestsDayFive
    {
        // Part One
        [TestMethod]
        public void TestVowels()
        {
            Assert.AreEqual(true, DayFive.checkVowels("ugknbfddgicrmopn"));
            Assert.AreEqual(false, DayFive.checkVowels("dvszwmarrgswjxmb"));
        }
        [TestMethod]
        public void TestDoubleLetters()
        {
            Assert.AreEqual(true, DayFive.checkDoubleLetters("ugknbfddgicrmopn"));
            Assert.AreEqual(false, DayFive.checkDoubleLetters("jchzalrnumimnmhp"));
        }
        [TestMethod]
        public void TestBadStrings()
        {
            Assert.AreEqual(true, DayFive.checkBadStrings("ugknbfddgicrmopn"));
            Assert.AreEqual(true, DayFive.checkBadStrings("aaa"));
            Assert.AreEqual(false, DayFive.checkBadStrings("haegwjzuvuyypxyu"));
        }
        [TestMethod]
        public void TestValidity()
        {
            Assert.AreEqual(true, DayFive.checkValidity("ugknbfddgicrmopn"));
            Assert.AreEqual(true, DayFive.checkValidity("aaa"));
            Assert.AreEqual(false, DayFive.checkValidity("jchzalrnumimnmhp"));
            Assert.AreEqual(false, DayFive.checkValidity("haegwjzuvuyypxyu"));
            Assert.AreEqual(false, DayFive.checkValidity("dvszwmarrgswjxmb"));
        }

        // Part Two
        [TestMethod]
        public void TestPart2DoubleLetters()
        {
            Assert.AreEqual(true, DayFive.checkPart2DoubleLetters("xyxy"));
            Assert.AreEqual(true, DayFive.checkPart2DoubleLetters("aabcdefgaa"));
            Assert.AreEqual(false, DayFive.checkPart2DoubleLetters("aaa"));
            Assert.AreEqual(true, DayFive.checkPart2DoubleLetters("qjhvhtzxzqqjkmpb"));
            Assert.AreEqual(true, DayFive.checkPart2DoubleLetters("xxyxx"));
            Assert.AreEqual(true, DayFive.checkPart2DoubleLetters("uurcxstgmygtbstg"));
            Assert.AreEqual(false, DayFive.checkPart2DoubleLetters("ieodomkazucvgmuy"));
        }
        [TestMethod]
        public void TestPart2InbetweenLetters()
        {
            Assert.AreEqual(true, DayFive.checkPart2RepeatingLetterWithInbetween("xyx"));
            Assert.AreEqual(true, DayFive.checkPart2RepeatingLetterWithInbetween("xxyxx"));
            Assert.AreEqual(true, DayFive.checkPart2RepeatingLetterWithInbetween("qjhvhtzxzqqjkmpb"));
            Assert.AreEqual(true, DayFive.checkPart2RepeatingLetterWithInbetween("abcdefeghi"));
            Assert.AreEqual(true, DayFive.checkPart2RepeatingLetterWithInbetween("aaa"));
            Assert.AreEqual(true, DayFive.checkPart2RepeatingLetterWithInbetween("ieodomkazucvgmuy"));
            Assert.AreEqual(false, DayFive.checkPart2RepeatingLetterWithInbetween("uurcxstgmygtbstg"));
        }
        [TestMethod]
        public void TestPart2Validity()
        {
            Assert.AreEqual(true, DayFive.checkValidityPart2("qjhvhtzxzqqjkmpb"));
            Assert.AreEqual(true, DayFive.checkValidityPart2("xxyxx"));
            Assert.AreEqual(false, DayFive.checkValidityPart2("uurcxstgmygtbstg"));
            Assert.AreEqual(false, DayFive.checkValidityPart2("ieodomkazucvgmuy"));
        }
    }
}
