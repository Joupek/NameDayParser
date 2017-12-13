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
            var expected = "Current date is name day for Antti";
            var nameparser = new NameDayParser.NameDay();
            var result =nameparser.FindNameDay("30.11.");
            Assert.AreSame(expected, result);

        }
        [TestMethod]
        public void DateValidTest()
        {
            string dateformat = "20.3.2015";
            Assert.IsTrue(NameDayParser.NameDay.IsDateTime(dateformat));
        }
    }
}
