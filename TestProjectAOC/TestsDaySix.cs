using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_AOC_D1;
using System.Linq;
using System.Collections.Generic;
using System.Windows;

namespace TestProjectAOC
{
    [TestClass]
    public class TestsDaySix
    {
        [TestMethod]
        public void TestTurnOn()
        {
            Dictionary<Point, Boolean> oLights = new Dictionary<Point, Boolean>();
            DaySix.oLights = oLights;

            DaySix.TurnOn(0, 3, 1, 1);
            oLights = DaySix.oLights;

            Assert.AreEqual(4, oLights.Where(v => v.Value == true).Count());
        }
    }
}
