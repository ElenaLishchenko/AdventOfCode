using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class CounterTests
    {
        [TestMethod()]
        [DataRow("z1ight234", 14)]
        [DataRow("23336", 26)]
        [DataRow("ds2sg3sgs33ssgs6", 26)]
        [DataRow("gfg2ssss3s33gs6", 26)]
        [DataRow("8", 88)]
        [DataRow("reerererer8sddsdsds", 88)]
        public void CountTest(string testData, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Counter.Count(testData));
        }
    }
}