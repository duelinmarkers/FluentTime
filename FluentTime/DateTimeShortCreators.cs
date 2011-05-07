using System;

namespace FluentTime
{
    public static class Today
    {
        public static DateTime At(int hour) { return AdjustableCurrentTime.Today.At(hour, 0, 0); }
        public static DateTime At(int hour, int minute) { return AdjustableCurrentTime.Today.At(hour, minute, 0); }
        public static DateTime At(int hour, int minute, int second) { return AdjustableCurrentTime.Today.At(hour, minute, second); }

   }

    public static class Tomorrow
    {
        public static DateTime At(int hour) { return AdjustableCurrentTime.Today.AddDays(1).At(hour, 0, 0); }
        public static DateTime At(int hour, int minute) { return AdjustableCurrentTime.Today.AddDays(1).At(hour, minute, 0); }
        public static DateTime At(int hour, int minute, int second) { return AdjustableCurrentTime.Today.AddDays(1).At(hour, minute, second); }
    }

    public static class Yesterday
    {
        public static DateTime At(int hour) { return AdjustableCurrentTime.Today.AddDays(-1).At(hour, 0, 0); }
        public static DateTime At(int hour, int minute) { return AdjustableCurrentTime.Today.AddDays(-1).At(hour, minute, 0); }
        public static DateTime At(int hour, int minute, int second) { return AdjustableCurrentTime.Today.AddDays(-1).At(hour, minute, second); }

     }

    public static class Next
    {
        private static DateTime GetNextOfDay(DayOfWeek dayOfWeek)
        {
            var today = AdjustableCurrentTime.Today;
            int delta = dayOfWeek - today.DayOfWeek;

            DateTime result = today.AddDays(delta <= 0 ? delta + 7 : delta);
            return result;
        }

        public static DateTime Monday() { return GetNextOfDay(DayOfWeek.Monday); }
        public static DateTime Tuesday() { return GetNextOfDay(DayOfWeek.Tuesday); }
        public static DateTime Wednesday() { return GetNextOfDay(DayOfWeek.Wednesday); }
        public static DateTime Thursday() { return GetNextOfDay(DayOfWeek.Thursday); }
        public static DateTime Friday() { return GetNextOfDay(DayOfWeek.Friday); }
        public static DateTime Saturday() { return GetNextOfDay(DayOfWeek.Saturday); }
        public static DateTime Sunday() { return GetNextOfDay(DayOfWeek.Sunday); }
    }

    public static class Last
    {
        private static DateTime GetLastOfDay(DayOfWeek dayOfWeek)
        {
            var today = AdjustableCurrentTime.Today;
            int delta = dayOfWeek - today.DayOfWeek;

            DateTime result = today.AddDays(delta >= 0 ? delta - 7 : delta);
            return result;
        }

        public static DateTime Monday() { return GetLastOfDay(DayOfWeek.Monday); }
        public static DateTime Tuesday() { return GetLastOfDay(DayOfWeek.Tuesday); }
        public static DateTime Wednesday() { return GetLastOfDay(DayOfWeek.Wednesday); }
        public static DateTime Thursday() { return GetLastOfDay(DayOfWeek.Thursday); }
        public static DateTime Friday() { return GetLastOfDay(DayOfWeek.Friday); }
        public static DateTime Saturday() { return GetLastOfDay(DayOfWeek.Saturday); }
        public static DateTime Sunday() { return GetLastOfDay(DayOfWeek.Sunday); }
    }
}
