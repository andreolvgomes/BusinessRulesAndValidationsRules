namespace BusinessRulesAndValidationsRules.Rules.Utils
{
    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
