using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _00179496_ManishBC_DDOOCP;
namespace UnitTest_Formulae
{
    [TestClass]
    public class UnitTestContext
    {
        [TestMethod]
        public void CheckEqual()
        {
            Context c = new Context();
            bool b = c.CheckEqual("=sum A1:A2");
            Assert.AreEqual(true, b);
        }

        [TestMethod]
        public void CheckNotEqual()
        {
            Context c = new Context();
            bool b = c.CheckEqual("adfadf");
            Assert.AreEqual(false, b);
        }
        [TestMethod]
        public void checkColon()
        {
            Context c = new Context();
            bool b = c.CheckColon("=sum A1:A2");
            Assert.AreEqual(true, b);
        }
        [TestMethod]
        public void checkNotColon()
        {
            Context c = new Context();
            bool b = c.CheckColon("asdasdf");
            Assert.AreEqual(false, b);
        }
        [TestMethod]
        public void checkEmpty()
        {
            Context c = new Context();
            bool b = c.CheckColon("acasdvasd");
            Assert.AreEqual(false, b);
        }
        [TestMethod]
        public void checkNotEmpty()
        {
            Context c = new Context();
            bool b = c.CheckEmpty("");
            Assert.AreEqual(true, b);
        }
       
    }
    
}
       


