namespace prep.infrastructure.filtering
{
    public interface IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType,ReturnType>
    {
        ReturnType create_using(IMatchAn<PropertyType> real_criteria);
    }
}