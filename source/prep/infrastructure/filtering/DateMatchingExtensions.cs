using System;

namespace prep.infrastructure.filtering
{
    public static class DateMatchingExtensions
    {
        public static ReturnType greater_than<ItemToMatch,ReturnType>(
    this IProvideAccessToCreatingMatchers<ItemToMatch, DateTime,ReturnType> extension_point, int value)
        {
            return extension_point.create_using(Where<DateTime>.has_a(x => x.Year).greater_than(value));
        }

        public static ReturnType between<ItemToMatch,ReturnType>(
            this IProvideAccessToCreatingMatchers<ItemToMatch, DateTime,ReturnType> extension_point, int start, int end)
        {
            return
                extension_point.create_using(Where<DateTime>.has_a(x => x.Year).between(start,end));
        }
    }
}
