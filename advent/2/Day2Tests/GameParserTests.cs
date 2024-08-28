using Day2;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Day2.Tests
{
    [TestClass()]
    public class GameParserTests
    {
        [TestMethod()]
        [DataRow("Game 1: 3 green, 1 blue, 3 red; 3 blue, 1 green, 3 red; 2 red, 12 green, 7 blue; 1 red, 4 blue, 5 green; 7 green, 2 blue, 2 red",
            "3 green, 1 blue, 3 red", "3 blue, 1 green, 3 red", "2 red, 12 green, 7 blue", "1 red, 4 blue, 5 green", "7 green, 2 blue, 2 red")]
        [DataRow("Game 2: 1 green, 19 blue, 1 red; 8 blue, 4 red; 3 red, 6 blue; 1 green, 1 red, 12 blue",
            "1 green, 19 blue, 1 red", "8 blue, 4 red", "3 red, 6 blue", "1 green, 1 red, 12 blue")]
        [DataRow("Game 3: 3 green, 1 blue, 9 red; 1 blue, 2 green, 8 red; 1 blue, 2 red",
            "3 green, 1 blue, 9 red", "1 blue, 2 green, 8 red", "1 blue, 2 red")]
        [DataRow("Game 4: 6 green, 2 red; 2 red, 16 green; 3 red, 1 blue",
            "6 green, 2 red", "2 red, 16 green", "3 red, 1 blue")]
        public void ParseGameTest(string line, params string[] expectedResult)
        {
            var parser = new GameParser();
            var result = parser.ParseGame(line);
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }

        [TestMethod()]
        [DataRow("Game 1: 3 green, 1 blue, 3 red; 3 blue, 1 green, 3 red; 2 red, 12 green, 7 blue; 1 red, 4 blue, 5 green; 7 green, 2 blue, 2 red", 1)]
        [DataRow("Game 2: 1 green, 19 blue, 1 red; 8 blue, 4 red; 3 red, 6 blue; 1 green, 1 red, 12 blue", 2)]
        [DataRow("Game 3: 3 green, 1 blue, 9 red; 1 blue, 2 green, 8 red; 1 blue, 2 red", 3)]
        [DataRow("Game 4: 6 green, 2 red; 2 red, 16 green; 3 red, 1 blue", 4)]
        public void FindGameNumberTest(string gameLine, int expectedGameNumber)
        {
            var parser = new GameParser();
            var result = parser.GetGameNumber(gameLine);
            Assert.AreEqual(expectedGameNumber, result);
        }
    }
}