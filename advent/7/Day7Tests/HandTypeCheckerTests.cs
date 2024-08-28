using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Day7.Tests
{
    [TestClass()]
    public class HandTypeCheckerTests
    {
        [DataTestMethod]
        [DataRow("12345", HandType.HighCard)]
        [DataRow("22345", HandType.OnePair)]
        [DataRow("11223", HandType.TwoPair)]
        [DataRow("11123", HandType.Three)]
        [DataRow("11122", HandType.FullHouse)]
        [DataRow("11112", HandType.Four)]
        [DataRow("11111", HandType.Five)]
        [DataRow("1234J", HandType.OnePair)]
        [DataRow("11J23", HandType.Three)]
        [DataRow("1JJ23", HandType.Three)]
        [DataRow("11J22", HandType.FullHouse)]
        [DataRow("11JJ2", HandType.Four)]
        [DataRow("1JJJ2", HandType.Four)]
        [DataRow("1JJJJ", HandType.Five)]
        [DataRow("11JJJ", HandType.Five)]
        public void GetTypeTest(string testCard, HandType expectedResult)
        {
            var result = HandTypeChecker.GetType(testCard);
            Assert.AreEqual(expectedResult, result);
        }
    }
}