using System;

namespace prep.infrastructure.filtering
{
    public class NegatingMatchExtensionPoint<ItemToMatch, PropertyType> :
        IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType>
    {
        IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> original;

        public NegatingMatchExtensionPoint(IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> original)
        {
            this.original = original;
        }

        public IMatchAn<ItemToMatch> create_using(IMatchAn<PropertyType> real_criteria)
        {
            return original.create_using(real_criteria).not();
        }
    }

    public class MatchingExtensionPoint<ItemToMatch,PropertyType> : IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType>
    {
        Func<ItemToMatch, PropertyType> accessor;

        public MatchingExtensionPoint(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> not
        {
            get
            {
                return new NegatingMatchExtensionPoint<ItemToMatch, PropertyType>(this);
            }
        }

        public IMatchAn<ItemToMatch> create_using(IMatchAn<PropertyType> real_criteria)
        {
            return new PropertyMatcher<ItemToMatch, PropertyType>(accessor, real_criteria);
        }
    }

    public class EnumerableExtensionPoint<ItemToMatch,PropertyType> : IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType>{
        IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> original;

        public EnumerableExtensionPoint( IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> original )
        {
            this.original = original;
        }

        public IMatchAn<ItemToMatch> create_using(IMatchAn<PropertyType> real_criteria)
        {
            return original.create_using(real_criteria).not();
        }
    }
}