using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Metadata;

namespace Day7.Tests
{
    [TestClass()]
    public class HandComparerTests
    {
        [DataTestMethod]
        [DataRow("12345 1", "12346 1", -1)]
        [DataRow("12345 1", "22345 1", -1)]
        [DataRow("12345 1", "22346 1", -1)]
        [DataRow("22345 1", "22333 1", -1)]
        [DataRow("12344 1", "12355 1", -1)]
        [DataRow("12333 1", "22333 1", -1)]
        [DataRow("13333 1", "33333 1", -1)]
        [DataRow("22345 1", "22333 1", -1)]
        [DataRow("1234J 1", "12344 1", -1)]
        [DataRow("123JJ 1", "12333 1", -1)]
        [DataRow("12J22 1", "12222 1", -1)]
        [DataRow("2222J 1", "22222 1", -1)]
        [DataRow("9JJJ9 1", "AAJAA 1", -1)]
        public void CompareTest(string card1, string card2, int expectedResult)
        {
            var comparer = new HandComparer();
            var hand1 = new Hand(card1);
            var hand2 = new Hand(card2);
            var result = comparer.Compare(hand1, hand2);
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ListCompareTest()
        {
            var handsList = new List<Hand>
            {
                new Hand("T6J0T 716"),
                new Hand("T6T0T 716"),
                new Hand("8J29Q 523"),
                new Hand("486TK 358"),
                new Hand("3AAAA 945"),
                new Hand("J5552 239"),
                new Hand("JJJJ2 239"),
            };
            handsList.Sort(new HandComparer());
            Assert.AreEqual(handsList[0].Card, "486TK");
            Assert.AreEqual(handsList[1].Card, "8J29Q");
            Assert.AreEqual(handsList[2].Card, "T6J0T");
            Assert.AreEqual(handsList[3].Card, "T6T0T");
            Assert.AreEqual(handsList[4].Card, "J5552");
            Assert.AreEqual(handsList[5].Card, "3AAAA");
            Assert.AreEqual(handsList[6].Card, "JJJJ2");
        }
    }
}