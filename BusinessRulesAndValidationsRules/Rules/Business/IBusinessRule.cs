namespace BusinessRulesAndValidationsRules.Rules.Business
{
    /// <summary>
    /// An interface that defines business rule for an entity instance.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that this business rule evaluates.</typeparam>
    public interface IBusinessRule<TEntity>
    {
        /// <summary>
        /// Evaulates the business rule against an entity instance.
        /// </summary>
        /// <param name="entity"><typeparamref name="TEntity"/>. The entity instance against which
        /// the business rule is evaulated.</param>
        void Evaluate(TEntity entity);
    }
}