using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.infrastructure.ranges {
    public class InclusiveType{
        public static readonly InclusiveType Inclusive = new InclusiveType();
        public static readonly InclusiveType Exclusive = new InclusiveType();
        public static readonly InclusiveType InclusiveMin = new InclusiveType();
        public static readonly InclusiveType InclusiveMax = new InclusiveType();
    }

    public class MinimumCriteria<T> : IMatchAn<T> where T:IComparable<T>{
        public bool inclusive { get; set; }
        public T MinValue { get; set; }

        public MinimumCriteria(){
        }

        public MinimumCriteria(T minValue){
            MinValue = minValue;
        }

        public bool matches(T item){
            if (inclusive)
                return item.CompareTo(MinValue) >= 0;
            else
                return item.CompareTo(MinValue) > 0;
        }
    }

    public class MaximumCriteria<T>: IMatchAn<T> where T:IComparable<T>{
        public bool inclusive { get; set; }
        public T MaxValue { get; set; }

        public MaximumCriteria(){
        }

        public MaximumCriteria(T maxValue){
            MaxValue = maxValue;
        }

        public bool matches( T item ) {
            if (inclusive)
                return item.CompareTo(MaxValue) <= 0;
            else
                return item.CompareTo(MaxValue) < 0;
        }
    }

    public class GenericRange<T> : IContainValues<T> where T : IComparable<T> {

        private MinimumCriteria<T> left_criteria = new MinimumCriteria<T>();
        private MaximumCriteria<T> right_criteria = new MaximumCriteria<T>();

        public GenericRange(T start, T end){
            left_criteria = new MinimumCriteria<T>(start);
            right_criteria = new MaximumCriteria<T>(end);
        }

        public GenericRange(){
        }

        public bool contains( T value ){
            return left_criteria.matches(value) && right_criteria.matches(value);
        }

        public GenericRange<T> greater_than(T lower_boundry){
            left_criteria.MinValue = lower_boundry;
            return this;
        }

        public GenericRange<T> less_than(T upper_boundry){
            right_criteria.MaxValue = upper_boundry;
            return this;
        }

        public GenericRange<T> lower_inclusive(){
            left_criteria.inclusive = true;
            return this;
        }

        public GenericRange<T> lower_exclusive(){
            left_criteria.inclusive = false;
            return this;
        }

        public GenericRange<T> upper_inclusive(){
            right_criteria.inclusive = true;
            return this;
        }

        public GenericRange<T> upper_exclusive(){
            right_criteria.inclusive = false;
            return this;
        }

        public static GenericRange<T> Make(){
            return new GenericRange<T>();
        }

        public static GenericRange<T> Make(T min, T max){
            return new GenericRange<T>(min, max);
        }
    }

}
