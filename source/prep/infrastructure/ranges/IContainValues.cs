using System;

namespace prep.infrastructure.ranges
{
    public interface IContainValues<T> where T : IComparable<T>
    {
        bool contains(T value);
    }
}