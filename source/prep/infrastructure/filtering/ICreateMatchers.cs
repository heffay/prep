namespace prep.infrastructure.filtering
{
    public interface ICreateMatchers<ItemToMatch, PropertyType>
    {
        IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal);
        IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values);
        IMatchAn<ItemToMatch> create_using(IMatchAn<PropertyType> real_criteria);
        IMatchAn<ItemToMatch> not_equal_to(PropertyType value);
    }
}