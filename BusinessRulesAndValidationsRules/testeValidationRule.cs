using BusinessRulesAndValidationsRules.Rules.Validator;
using BusinessRulesAndValidationsRules.Rules.Business;
using BusinessRulesAndValidationsRules.Rules.Utils;

namespace BusinessRulesAndValidationsRules
{
    public class ValidaUser
    {
        public void ChangePassword(User user, string newPassword)
        {
            Specification<string> moreThan5 = new Specification<string>(x => x.Length > 5);
            Specification<string> hasUpper = new Specification<string>(x => HasUpperCase(x));
            Specification<string> hasNumeric = new Specification<string>(x => HasNumeric(x));

            ValidationRule<string> validatePassword = new ValidationRule<string>(new List<ISpecification<string>>() { moreThan5, hasUpper, hasNumeric },
                                                                                 "The password provided does not match the password restriction policy. Your new password must be" +
                                                                                 "at least 6 characters long with one upper case and one numeric character",
                                                                                 "New Password");

            if (!validatePassword.Validate(newPassword))
            {
                //Show the error...
            }
        }

        public bool HasUpperCase(string value)
        {
            foreach (var character in value)
            {
                if (char.IsUpper(character)) return true;
            }
            return false;
        }

        public bool HasNumeric(string value)
        {
            foreach (var character in value)
            {
                if (char.IsUpper(character)) return true;
            }
            return false;
        }
    }

    public class Customer
    {
        public List<Order> Orders { get; set; }
        public int CustomerClass { get; internal set; }
    }

    public class Items
    {

    }

    public class Order
    {
        public int TotalValue { get; internal set; }
        public Customer Customer { get; internal set; }
        public List<Items> Items { get; set; }
        public DateTime OrderDate { get; internal set; }
    }

    public interface IRepository<T>
    {
        void Save(Order order);
    }
    public class Repository<T> : IRepository<Order>
    {
        public void Save(Order order)
        {
        }
    }

    public class OrdersService
    {
        private IEntityValidator<Order> _ordersValidator;
        private IRepository<Order> _orderRepository;

        public OrdersService(IEntityValidator<Order> orderValidator, IRepository<Order> orderRepository)
        {
            _ordersValidator = orderValidator;
            _orderRepository = orderRepository;
        }

        public void SaveOrder(Order order)
        {
            //Snip... Save order to database...
            BusinessRule<Order> urgeDeliveryForHighProfileOrders = new BusinessRule<Order>(IsHighProfileOrder(), MarkUrgent);
            urgeDeliveryForHighProfileOrders.Evaluate(order);
        }

        private void MarkUrgent(Order order)
        {
            //Snip... Mark the order in the database urgent...
        }

        public ISpecification<Order> IsHighProfileOrder()
        {
            return new Specification<Order>(x => x.Customer.Orders.Sum(order => order.TotalValue) > 100000);
        }

        public void SaveOrder2(Order order)
        {
            ValidationResult validateResult = _ordersValidator.Validate(order);
            if (!validateResult.IsValid)
                throw new ValidationException(validateResult);
            _orderRepository.Save(order);
        }
    }

    public class CustomerClass
    {
        public static decimal Platinum { get; set; }
    }

    public static class OrderSpecifications
    {
        public static Specification<Order> LowValueCustomer() { return new Specification<Order>(order => order.Customer.CustomerClass < CustomerClass.Platinum); }

        public static Specification<Order> HighOrderValue()
        {
            return new Specification<Order>(order => order.TotalValue > 40000);
        }
    }
}