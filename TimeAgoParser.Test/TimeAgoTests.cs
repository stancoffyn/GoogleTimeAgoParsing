using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace TimeAgoParser.Test
{
    [TestClass]
    public class TimeAgoTests
    {
        [DataTestMethod]
        [DataRow("1 hour ago", 3600, 1)]
        [DataRow("2 hours ago", 3600, 2)]
        [DataRow("3 hours ago", 3600, 3)]
        [DataRow("4 hours ago", 3600, 4)]
        [DataRow("5 hours ago", 3600, 5)]
        [DataRow("6 hours ago", 3600, 6)]
        [DataRow("7 hours ago", 3600, 7)]
        [DataRow("8 hours ago", 3600, 8)]
        [DataRow("9 hours ago", 3600, 9)]
        [DataRow("10 hours ago", 3600, 10)]
        [DataRow("11 hours ago", 3600, 11)]
        [DataRow("12 hours ago", 3600, 12)]
        [DataRow("13 hours ago", 3600, 13)]
        [DataRow("14 hours ago", 3600, 14)]
        [DataRow("15 hours ago", 3600, 15)]
        [DataRow("16 hours ago", 3600, 16)]
        [DataRow("17 hours ago", 3600, 17)]
        [DataRow("18 hours ago", 3600, 18)]
        [DataRow("19 hours ago", 3600, 19)]
        [DataRow("20 hours ago", 3600, 20)]
        [DataRow("21 hours ago", 3600, 21)]
        [DataRow("22 hours ago", 3600, 22)]
        [DataRow("23 hours ago", 3600, 23)]
        [DataRow("24 hours ago", 3600, 24)]
        [DataRow("Yesterday", 86400, 1)]
        [DataRow("a day ago", 86400, 1)]
        [DataRow("2 days ago", 86400, 2)]
        [DataRow("3 days ago", 86400, 3)]
        [DataRow("4 days ago", 86400, 4)]
        [DataRow("5 days ago", 86400, 5)]
        [DataRow("6 days ago", 86400, 6)]
        [DataRow("a week ago", 604800, 1)]
        [DataRow("2 weeks ago", 604800, 2)]
        [DataRow("3 weeks ago", 604800, 3)]
        [DataRow("4 weeks ago", 604800, 4)]
        [DataRow("a month ago", -1, 1)]
        [DataRow("2 months ago", -1, 2)]
        [DataRow("3 months ago", -1, 3)]
        [DataRow("4 months ago", -1, 4)]
        [DataRow("5 months ago", -1, 5)]
        [DataRow("6 months ago", -1, 6)]
        [DataRow("7 months ago", -1, 7)]
        [DataRow("8 months ago", -1, 8)]
        [DataRow("9 months ago", -1, 9)]
        [DataRow("10 months ago", -1, 10)]
        [DataRow("11 months ago", -1, 11)]
        [DataRow("a year ago", 220903200, 1)]
        [DataRow("2 years ago", 220903200, 2)]
        [DataRow("3 years ago", 220903200, 3)]
        [DataRow("4 years ago", 220903200, 4)]
        [DataRow("5 years ago", 220903200, 5)]
        [DataRow("6 years ago", 220903200, 6)]
        [DataRow("7 years ago", 220903200, 7)]
        [DataRow("8 years ago", 220903200, 8)]
        [DataRow("9 years ago", 220903200, 9)]
        [DataRow("10 years ago", 220903200, 10)]
        [DataRow("11 years ago", 220903200, 11)]
        [DataRow("12 years ago", 220903200, 12)]
        [DataRow("13 years ago", 220903200, 13)]
        [DataRow("14 years ago", 220903200, 14)]
        [DataRow("15 years ago", 220903200, 15)]
        public void TestKownStrings(string timeAgoString, int expectedSecondsPerUnit, int unitFromString)
        {
            var timeOffset = DateTimeOffset.Now;
            DateTimeOffset offset = TimeAgoParser.Lib.TimeAgoParser
                .GetOffsetFromRelativeTimeString(timeAgoString, timeOffset);
            if(expectedSecondsPerUnit == -1)
            {
                Assert.AreEqual(timeOffset.AddMonths(-1 * unitFromString), offset);
            }
            else {
                Assert.AreEqual(timeOffset.AddSeconds(-1 * expectedSecondsPerUnit * unitFromString), offset);
            }
        }
    }
}
