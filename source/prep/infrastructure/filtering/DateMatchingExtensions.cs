using System;

namespace prep.infrastructure.filtering
{
    public static class DateMatchingExtensions
    {
        public static IMatchAn<ItemToMatch> greater_than<ItemToMatch>(
    this MatchingExtensionPoint<ItemToMatch, DateTime> extension_point, int value)
        {
            return extension_point.create_using(Where<DateTime>.has_a(x => x.Year).greater_than(value));
        }

        public static IMatchAn<ItemToMatch> between<ItemToMatch>(
            this MatchingExtensionPoint<ItemToMatch, DateTime> extension_point, int start, int end)
        {
            return
                extension_point.create_using(Where<DateTime>.has_a(x => x.Year).between(start,end));
        }
    }
}
