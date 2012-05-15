namespace prep.infrastructure.filtering
{
    public interface IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType>
    {
        IMatchAn<ItemToMatch> create_using(IMatchAn<PropertyType> real_criteria);
    }
}