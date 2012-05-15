using System;

namespace prep.infrastructure.filtering
{
    public class NegatingMatchExtensionPoint<ItemToMatch, PropertyType> :
        IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType,IMatchAn<ItemToMatch>>
    {
        IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType,IMatchAn<ItemToMatch>> original;

        public NegatingMatchExtensionPoint(IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType,IMatchAn<ItemToMatch>> original)
        {
            this.original = original;
        }

        public IMatchAn<ItemToMatch> create_using(IMatchAn<PropertyType> real_criteria)
        {
            return original.create_using(real_criteria).not();
        }
    }

    public class MatchingExtensionPoint<ItemToMatch,PropertyType> : IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType,IMatchAn<ItemToMatch>>
    {
        Func<ItemToMatch, PropertyType> accessor;

        public MatchingExtensionPoint(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType,IMatchAn<ItemToMatch>> not
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
}