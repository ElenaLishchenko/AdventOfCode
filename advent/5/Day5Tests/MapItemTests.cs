using Day5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace Day5.Tests
{
    [TestClass()]
    public class MapItemTests
    {
        [TestMethod()]
        public void ContainsTest()
        {
            var mapItem = new MapItem("10 10 10");
            Assert.IsTrue(mapItem.RangeContains(new Range(9, 2)));
            Assert.IsTrue(mapItem.RangeContains(new Range(19, 2)));
            Assert.IsTrue(mapItem.RangeContains(new Range(15, 2)));
            Assert.IsTrue(mapItem.RangeContains(new Range(9, 20)));
            Assert.IsFalse(mapItem.RangeContains(new Range(9, 1)));
            Assert.IsFalse(mapItem.RangeContains(new Range(20, 2)));
        }

        [TestMethod()]
        public void SplitOverRangeTest()
        {
            var mapItem = new MapItem("100 10 10");
            var range = new Range(9, 12);
            var result = mapItem.SplitRange(range);
            Assert.AreEqual(result.MappedRange.Start, (uint)100);
            Assert.AreEqual(result.MappedRange.Length, (uint)10);
            Assert.AreEqual(result.NotMappedRanges.Count, 2);
            Assert.AreEqual(result.NotMappedRanges[0].Start, (uint)9);
            Assert.AreEqual(result.NotMappedRanges[0].Length, (uint)1);
            Assert.AreEqual(result.NotMappedRanges[1].Start, (uint)20);
            Assert.AreEqual(result.NotMappedRanges[1].Length, (uint)1);
        }

        [TestMethod()]
        public void SplitOutOfMapRangeTest()
        {
            var mapItem = new MapItem("100 10 10");
            var range = new Range(2, 2);
            var result = mapItem.SplitRange(range);

            Assert.AreEqual(result.MappedRange, null);
            Assert.AreEqual(result.NotMappedRanges.First(), range);
        }

        [TestMethod()]
        public void SplitIntoMapRangeTest()
        {
            var mapItem = new MapItem("100 10 10");
            var range = new Range(11, 3);
            var result = mapItem.SplitRange(range);
            Assert.AreEqual(result.NotMappedRanges.Count, 0);
            Assert.AreEqual(result.MappedRange.Start, (uint)101);
            Assert.AreEqual(result.MappedRange.Length, (uint)3);
        }
    }
}