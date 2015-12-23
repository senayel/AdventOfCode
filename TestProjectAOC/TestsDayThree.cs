using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_AOC_D1;
using System.Windows;
using System.Collections.Generic;

namespace TestProjectAOC
{
    [TestClass]
    public class TestsDayThree
    {
        [TestMethod]
        public void TestMove() // change Name
        {
            Point wPoint = new Point(0, 0);
            DayThree.move('^', ref wPoint);
            Assert.AreEqual(new Point(1, 0), wPoint);
        }
        [TestMethod]
        public void TestDeliverPresent()
        {
            Dictionary<Point, int> wlPresents = new Dictionary<Point, int>();
            wlPresents.Add(new Point(2, 2), 1);
            Assert.AreEqual(1, wlPresents.Count);
            Assert.AreEqual(1, wlPresents[new Point(2, 2)]);
            DayThree.deliverPresent(wlPresents, new Point(2, 2));
            Assert.AreEqual(1, wlPresents.Count);
            Assert.AreEqual(2, wlPresents[new Point(2, 2)]);
            DayThree.deliverPresent(wlPresents, new Point(1, 1));
            Assert.AreEqual(2, wlPresents.Count);
            Assert.AreEqual(1, wlPresents[new Point(1, 1)]);
        }
    }
}
