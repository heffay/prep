namespace prep.infrastructure
{
    public delegate bool Criteria<in ItemToMatch>(ItemToMatch item);
}