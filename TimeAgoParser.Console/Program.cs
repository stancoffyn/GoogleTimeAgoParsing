using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TimeAgoParser.Lib;

namespace TimeAgoParser.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var timeOffset = DateTimeOffset.Now;
            var result = TimeAgoParser.Lib.TimeAgoParser.GetOffsetFromRelativeTimeString("Yesterday", timeOffset);
            System.Console.WriteLine(timeOffset);
        }
    }
}
