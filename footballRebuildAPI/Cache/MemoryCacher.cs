using System;

namespace Football.API.Cache
{
    public static class MemoryCacher
    {
        public static DateTime? _dateTime;
        public static bool _live;

        public static DateTime? getDateTime()
        {
            return _dateTime;
        }

        public static void setDateTime(DateTime? dateTime)
        {
            _dateTime = dateTime;
        }

        public static bool getLive()
        {
            return _live;
        }

        public static void setLive(bool live)
        {
            _live = live;
        }
    }
}
