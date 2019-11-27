using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TimeAgoParser.Lib;
namespace TimeAgoParser.Lib
{
    public static class TimeAgoParser
    {
        public static DateTimeOffset GetOffsetFromRelativeTimeString(string relativeTimeString, DateTimeOffset offset)
        {
            var regexForValueParse = new Regex(@"(?<value>[0-9]{1,3})");
            var regexForSingleValueParse = new Regex(@"a\s");
            var enumName = Enum.GetNames(typeof(TimeSegmentEnum))
                .Where(name => relativeTimeString.ToLower().Contains(name.ToLower()))
                .FirstOrDefault();
            var enumFoundInString = (TimeSegmentEnum)Enum.Parse(typeof(TimeSegmentEnum), enumName);
            var matchForValue = regexForValueParse.Match(relativeTimeString);
            int value = 1;
            if (!matchForValue.Success && !(regexForSingleValueParse.Match(relativeTimeString).Success || relativeTimeString.ToLower().Contains("yesterday")))
                throw new InvalidOperationException("No valid time segment was found for a non valued relative time (i.e. Yesterday or a month ago)");
            else if (matchForValue.Success)
                value = int.Parse(matchForValue.Value);

            if (enumFoundInString == TimeSegmentEnum.month)
                return offset.AddMonths(-1 * value);
            else
                return offset.AddSeconds(-1 * value * ((int)enumFoundInString));
        }
    }
}
