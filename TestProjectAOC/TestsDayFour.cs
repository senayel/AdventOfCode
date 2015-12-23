using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_AOC_D1;
using System.Windows;
using System.Collections.Generic;

namespace TestProjectAOC
{
    [TestClass]
    public class TestsDayFour
    {
        [TestMethod]
        public void TestGetSecretKey()
        {
            Assert.AreEqual(609043, DayFour.getSecretKey("abcdef"));
            Assert.AreEqual(1048970, DayFour.getSecretKey("pqrstuv"));
            Assert.AreEqual(346386, DayFour.getSecretKey("iwrupvqb"));
        }
        [TestMethod]
        public void TestGenerateKey()
        {
            Assert.AreEqual("abcdef609043", DayFour.generateKey("abcdef", 609043));
            Assert.AreEqual("pqrstuv1048970", DayFour.generateKey("pqrstuv", 1048970));
        }
        [TestMethod]
        public void TestMD5Hash()
        {
            Assert.AreEqual("C3FCD3D76192E4007DFB496CCA67E13B", DayFour.calculateMD5Hash("abcdefghijklmnopqrstuvwxyz"));
        }
    }
}
