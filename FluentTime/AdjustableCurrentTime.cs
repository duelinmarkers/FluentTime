using System;

namespace FluentTime
{
    internal static class AdjustableCurrentTime
    {
        private static DateTime? _overrideNow;

        internal static void SetNow(DateTime now)
        {
            _overrideNow = now;
        }
        internal static void Reset()
        {
            _overrideNow = null;
        }

        public static DateTime Now
        {
            get { return _overrideNow ?? DateTime.Now; }
        }

        public static DateTime Today
        {
            get { return _overrideNow.HasValue ? _overrideNow.Value.Date : DateTime.Today; }
        }
    }
}
