using BusinessRulesAndValidationsRules.Rules.Utils;
using BusinessRulesAndValidationsRules.Rules.Validator;

namespace BusinessRulesAndValidationsRules.Rules
{
    public class OrderValidator : EntityValidatorBase<Order>
    {
        public OrderValidator()
        {
            AddValidation("BackOrderValidation",
                          new ValidationRule<Order>(
                              new Specification<Order>(order => order.OrderDate > DateTime.Now.AddDays(-1)),
                              "Order date cannot be backdated.", "OrderDate"));

            AddValidation("OrderItemsCountValidation", new ValidationRule<Order>(new Specification<Order>(order => order.Items.Count() > 0),
                                                    "Order must contain at least one item", "Order Items"));

            AddValidation("HighValueOrderForSilverCustomers", new ValidationRule<Order>(new List<ISpecification<Order>>() { OrderSpecifications.LowValueCustomer(), OrderSpecifications.HighOrderValue() },
                              "Cannot place a high value order. Please apply for Gold membership", "Order"));
        }
    }
}