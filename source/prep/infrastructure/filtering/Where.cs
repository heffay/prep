using System;

namespace prep.infrastructure.filtering
{
    public class Where<ItemToMatch>
    {
        public static CriteriaFactory<ItemToMatch, PropertyType> has_a<PropertyType>(
            Func<ItemToMatch, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToMatch, PropertyType>(
                accessor,
                new AnonymousMatchFactory<ItemToMatch>());
        }

        public static ComparableCriteriaFactory<ItemToMatch, PropertyType> has_an<PropertyType>(
            Func<ItemToMatch, PropertyType> accessor) where PropertyType : IComparable<PropertyType>
        {
            var factory = new AnonymousMatchFactory<ItemToMatch>();
            return new ComparableCriteriaFactory<ItemToMatch, PropertyType>(
                accessor,
                new CriteriaFactory<ItemToMatch, PropertyType>(accessor, factory), 
                factory);
        }
    }
}