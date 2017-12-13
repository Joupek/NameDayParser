using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ParserTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFindAntti()
        {
            var expected = "Antti";
            var nameparser = new NameDayParser.NameDay();
            var result =nameparser.FindNameDay("30.11.");
            Assert.AreEqual(expected, result);

        }
        [TestMethod]
        public void TestFindNothing()
        {
            var expected = string.Empty;
            var nameparser = new NameDayParser.NameDay();
            var result = nameparser.FindNameDay("30.11");
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        public void DateValidTestOK()
        {
            string dateformat = "20.3.2015";
            Assert.IsTrue(NameDayParser.NameDay.IsDateTime(dateformat));
        }
        [TestMethod]
        public void DateValidTestFail()
        {
            string dateformat = "33.3.2015";
            Assert.IsFalse(NameDayParser.NameDay.IsDateTime(dateformat));
        }
    }
}
