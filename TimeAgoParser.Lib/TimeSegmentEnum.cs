namespace TimeAgoParser.Lib {
    public enum TimeSegmentEnum{
        second = 1,
        minute = 60,
        hour = 3600,
        day = 86400,
        yesterday = 86400,
        week = 604800,
        month = -1, //months are a bit different, as they vary in length 28-31 days. will do special handling here
        year = 220903200
    }
}