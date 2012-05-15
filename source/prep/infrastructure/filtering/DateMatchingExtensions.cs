using System;

namespace prep.infrastructure.filtering
{
    public static class DateMatchingExtensions
    {
        public static IMatchAn<ItemToMatch> greater_than<ItemToMatch>(
    this MatchingExtensionPoint<ItemToMatch, DateTime> extension_point, DateTime value)
        {
            return extension_point.create_using(new FallsInRange<DateTime>(new Range<DateTime>().GreaterThan(value).Range));
        }

        public static IMatchAn<ItemToMatch> between<ItemToMatch>(
            this MatchingExtensionPoint<ItemToMatch, DateTime> extension_point, int start, int end)
        {
            return
                extension_point.create_using(new FallsInRange<DateTime>(
                                         new Range<DateTime>().GreaterThan(new DateTime(start, 1, 1, 0, 0, 0, 0)).Inclusive().And.LessThan(new DateTime(end, 12, 31, 23, 59, 59, 999)).Inclusive().Range));
        }
    }
}
