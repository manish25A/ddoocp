using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _00179496_ManishBC_DDOOCP;
namespace UnitTest_Formulae
{
    [TestClass]
    public class UnitTestFormula
    {
          [TestMethod]
        public void checksum()
        {
           Formulae fo = new Formulae();
            List<double> arr = new List<double>() { 5, 5, 9 };
            double result = fo.Sum(arr);
            Assert.AreEqual(19, result);
        }
          [TestMethod]
        public void CheckAverage()
        {
            Formulae fo = new Formulae();
            List<double> arr = new List<double>() { 40, 50, 60 };
            double result = fo.Average(arr);
            Assert.AreEqual(50, result);
        }
         [TestMethod]
        public void CheckMedian()
        {
            Formulae fo = new Formulae();
            List<double> arr = new List<double>() { 1, 2, 3, 4, 5 };
            double result = fo.Median(arr);
            Assert.AreEqual(3, result);
        }
        
        [TestMethod]
        public void CheckMode()
        {
            Formulae fo = new Formulae();
            List<double> arr = new List<double>() { 2, 4, 4, 1, 2, 4 };
            double result = fo.Mode(arr);
            Assert.AreEqual(4, result);
        }

            [TestMethod]
        public void CheckMultiply()
        {
            Formulae fo = new Formulae();
            List<double> arr = new List<double>() { 2, 5 };
            double result = fo.Multiply(arr);
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void CheckMean()
        {
            Formulae fo = new Formulae();
            List<double> arr = new List<double>() { 30, 40, 20 };
            double result = fo.Mean(arr);
            Assert.AreEqual(30, result);
        }
    }
}
