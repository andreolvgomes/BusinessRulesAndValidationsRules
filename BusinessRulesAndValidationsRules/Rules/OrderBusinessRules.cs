using BusinessRulesAndValidationsRules.Rules.Business;
using BusinessRulesAndValidationsRules.Rules.Utils;

namespace BusinessRulesAndValidationsRules.Rules
{
    public class OrderBusinessRules : BusinessRulesEvaulatorBase<Order>
    {
        public OrderBusinessRules()
        {
            AddRule("PlaceHighValueOrdersInImmediateQueue",
                    new BusinessRule<Order>(OrderSpecifications.HighOrderValue(), PlaceOrderInImmediateProcessingQueue));

            AddRule("SetBackOrderIfItemsNotInStock",
                    new BusinessRule<Order>(new Specification<Order>(x => HasItemThatIsNotInStock(x)),
                                            SetOrderAsBackorder));
        }

        private void PlaceOrderInImmediateProcessingQueue(Order order)
        {
            //Snip...
        }

        private bool HasItemThatIsNotInStock(Order order)
        {
            //Snip...
            return false;
        }

        private void SetOrderAsBackorder(Order order)
        {
            //Snip...
        }
    }
}