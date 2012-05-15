using System.Collections.Generic;

namespace prep.infrastructure.filtering
{
    public class NegatingIterationExtensionPoint<ItemToMatch, PropertyType> :
        IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType, IEnumerable<ItemToMatch>>
    {
        IEnumerable<ItemToMatch> items;
        IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType, IMatchAn<ItemToMatch>>
            original_extension_point;


        public NegatingIterationExtensionPoint(IEnumerable<ItemToMatch> items,
                                       IProvideAccessToCreatingMatchers
                                           <ItemToMatch, PropertyType, IMatchAn<ItemToMatch>> original_extension_point)
        {
            this.items = items;
            this.original_extension_point = original_extension_point;
        }

        public IEnumerable<ItemToMatch> create_using(IMatchAn<PropertyType> real_criteria)
        {
            return items.all_items_matching(original_extension_point.create_using(real_criteria).not());
        }
    }

    public class IterationExtensionPoint<ItemToMatch, PropertyType> :
        IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType, IEnumerable<ItemToMatch>>
    {
        IEnumerable<ItemToMatch> items;
        IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType, IMatchAn<ItemToMatch>>
            original_extension_point;


        public IterationExtensionPoint(IEnumerable<ItemToMatch> items,
                                       IProvideAccessToCreatingMatchers
                                           <ItemToMatch, PropertyType, IMatchAn<ItemToMatch>> original_extension_point)
        {
            this.items = items;
            this.original_extension_point = original_extension_point;
        }

        public IProvideAccessToCreatingMatchers<ItemToMatch,PropertyType,IEnumerable<ItemToMatch>> not
        {
            get{ return new NegatingIterationExtensionPoint<ItemToMatch, PropertyType>(items, original_extension_point);}
        }
        public IEnumerable<ItemToMatch> create_using(IMatchAn<PropertyType> real_criteria)
        {
            return items.all_items_matching(original_extension_point.create_using(real_criteria));
        }
    }
}