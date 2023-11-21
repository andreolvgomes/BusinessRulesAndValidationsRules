namespace BusinessRulesAndValidationsRules.Rules.Utils
{
    public class Specification<T> : ISpecification<T>
    {
        private Func<T, bool> _predicate;

        public Specification(Func<T, bool> predicate)
        {
            _predicate = predicate;
        }
        public bool IsSatisfiedBy(T entity)
        {
            return _predicate(entity);
        }
    }
}