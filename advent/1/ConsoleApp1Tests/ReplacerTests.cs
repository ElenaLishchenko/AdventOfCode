using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1.Tests
{
    [TestClass()]
    public class ReplacerTests
    {
        [TestMethod()]
        [DataRow("two1nine", "219")]
        [DataRow("eightwoninerrrthree", "8wo9rrr3")]
        [DataRow("abcone2threexyz", "abc123xyz")]
        [DataRow("4nineeightseven2", "49872")]
        [DataRow("vt81pzcchsvz", "vt81pzcchsvz")]
        [DataRow("eightrttrsixrtrt349jr", "8rttr6rtrt349jr")]
        [DataRow("8czmcdhjzpsbpjgngdvtxczgsl6th36", "8czmcdhjzpsbpjgngdvtxczgsl6th36")]
        [DataRow("4nineeightsevenfour2", "498742")]
        [DataRow("eightfive349jr", "85349jr")]
        [DataRow("zoneight234", "z1ight234")]
        public void ReplaceTest(string data, string expectedResult)
        {
            Assert.AreEqual(expectedResult, Replacer.Replace(data));
        }

        [TestMethod()]
        [DataRow("two1nine", 29)]
        [DataRow("6oneeightnine6", 66)]
        [DataRow("3eightnineonesixslhkjqgmreight", 38)]
        [DataRow("1seven74", 14)]
        [DataRow("gfqhnhjgt762zfgpzdzdhh1", 71)]
        [DataRow("79tfnmsevennnmsdrgzlsg", 77)]
        [DataRow("eight1seven5", 85)]
        [DataRow("7bzz199threecmnrn", 73)]
        [DataRow("5six4", 54)]
        [DataRow("sdasasdsixasdsadads", 66)]
        public void CountAndReplaceTest(string data, int expectedResult)
        {
            Assert.AreEqual(expectedResult, Replacer.CountAndReplace(data));
        }
    }
}