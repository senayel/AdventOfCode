using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_AOC_D1;
using System.Collections.Generic;

namespace TestProjectAOC
{
    [TestClass]
    public class TestsDayTwo
    {
        [TestMethod]
        public void TestPresentSurface()
        {
            Assert.AreEqual(58, DayTwo.getPresentSurface(2, 3, 4));
            Assert.AreEqual(43, DayTwo.getPresentSurface(1, 1, 10));
        }
        [TestMethod]
        public void TestBoxVolume()
        {
            Assert.AreEqual(24, DayTwo.getBoxVolume(2, 3, 4));
            Assert.AreEqual(10, DayTwo.getBoxVolume(1, 1, 10));
        }
        [TestMethod]
        public void TestRibbonLength()
        {
            Assert.AreEqual(34, DayTwo.getRibbonLength(2, 3, 4));
            Assert.AreEqual(14, DayTwo.getRibbonLength(1, 1, 10));
        }
        [TestMethod]
        public void TestBoxSurface()
        {
            Assert.AreEqual(52, DayTwo.getBoxSurface(new List<int>() { 12,24,16 }));
            Assert.AreEqual(42, DayTwo.getBoxSurface(new List<int>() { 2,20,20 }));
        }
        [TestMethod]
        public void TestSmallestSidesLength()
        {
            Assert.AreEqual(10, DayTwo.getSmallestSidesLength(new List<int>() { 2, 3, 4 }));
            Assert.AreEqual(4, DayTwo.getSmallestSidesLength(new List<int>() { 1, 1, 10 }));
        }
        [TestMethod]
        public void TestSideOneSize()
        {
            Assert.AreEqual(12, DayTwo.getSideOneSize(2, 3));
        }
        [TestMethod]
        public void TestSideTwoSize()
        {
            Assert.AreEqual(24, DayTwo.getSideOneSize(3, 4));
        }
        [TestMethod]
        public void TestSideThreeSize()
        {
            Assert.AreEqual(16, DayTwo.getSideOneSize(2, 4));
        }
        [TestMethod]
        public void TestSmallestSize()
        {
            Assert.AreEqual(2, DayTwo.getSmallestSide(new List<int>() { 4, 2, 3 }));
        }
    }
}
