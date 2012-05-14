namespace prep.infrastructure
{
    public interface IMatchAn<in Item>
    {
        bool matches(Item item);
    }
}