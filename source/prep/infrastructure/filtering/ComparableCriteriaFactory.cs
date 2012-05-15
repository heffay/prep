using System;

namespace prep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType>  : IEqualityCriteriaFactory<ItemToMatch, PropertyType>
     where PropertyType : IComparable<PropertyType> 
    {
        Func<ItemToMatch, PropertyType> accessor;
        private readonly CriteriaFactory<ItemToMatch, PropertyType> _criteriaFactory;
        private readonly AnonymousMatchFactory<ItemToMatch> _anonymousMatchFactory;

        public ComparableCriteriaFactory(Func<ItemToMatch, PropertyType> accessor, 
            CriteriaFactory<ItemToMatch, PropertyType> criteriaFactory,
            AnonymousMatchFactory<ItemToMatch> anonymousMatchFactory )
        {
            this.accessor = accessor;
            _criteriaFactory = criteriaFactory;
            _anonymousMatchFactory = anonymousMatchFactory;
        }

        public IMatchAn<ItemToMatch> greater_than(PropertyType value)
        {
            return _anonymousMatchFactory.GetInstance(x => accessor(x).CompareTo(value) > 0);
        }

        public IMatchAn<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            return
                _anonymousMatchFactory.GetInstance(
                    x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
        }

        public IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal)
        {
            return _criteriaFactory.equal_to(value_to_equal);
        }

        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return _criteriaFactory.equal_to_any(values);
        }

        public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
        {
            return _criteriaFactory.not_equal_to(value);
        }
    }
}