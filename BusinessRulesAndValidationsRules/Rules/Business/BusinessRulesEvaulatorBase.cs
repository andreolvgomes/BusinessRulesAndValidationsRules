namespace BusinessRulesAndValidationsRules.Rules.Business
{
    public abstract class BusinessRulesEvaulatorBase<TEntity> : IBusinessRulesEvaluator<TEntity> where TEntity : class
    {
        #region fields
        //The internal dictionary used to store rule sets.
        private readonly Dictionary<string, IBusinessRule<TEntity>> _ruleSets = new Dictionary<string, IBusinessRule<TEntity>>();
        #endregion

        #region methods
        /// <summary>
        /// Adds a <see cref="IBusinessRule{TEntity}"/> instance to the rules evaluator.
        /// </summary>
        /// <param name="rule">The <see cref="IBusinessRule{TEntity}"/> instance to add.</param>
        /// <param name="ruleName">string. The unique name assigned to the business rule.</param>
        protected void AddRule(string ruleName, IBusinessRule<TEntity> rule)
        {
            //Guard.Against<ArgumentNullException>(rule == null,
            //                                     "Cannot add a null rule instance. Expected a non null reference.");
            //Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName),
            //                                     "Cannot add a rule with an empty or null rule name.");
            //Guard.Against<ArgumentException>(_ruleSets.ContainsKey(ruleName),
            //                                 "Another rule with the same name already exists. Cannot add duplicate rules.");

            _ruleSets.Add(ruleName, rule);
        }

        /// <summary>
        /// Removes a previously added rule, specified with the <paramref name="ruleName"/>, from the evaluator.
        /// </summary>
        /// <param name="ruleName">string. The name of the rule to remove.</param>
        protected void RemoveRule(string ruleName)
        {
            //Guard.Against<ArgumentNullException>(string.IsNullOrEmpty(ruleName), "Expected a non empty and non-null rule name.");
            _ruleSets.Remove(ruleName);
        }

        /// <summary>
        /// Evaulates all business rules registred with the evaluator against a entity instance.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> instance against which all
        /// registered business rules are evauluated.</param>
        public void Evaulate(TEntity entity)
        {
            //Guard.Against<ArgumentNullException>(entity == null, "Cannot evaulate rules against a null reference. Expected a valid non-null entity instance.");
            _ruleSets.Keys.ToList().ForEach(x => EvaulateRule(x, entity));
        }

        /// <summary>
        /// Evaulates a business rules against an entity.
        /// </summary>
        /// <param name="ruleName">string. The name of the rule to evaulate.
        /// <param name="entity">A <typeparamref name="TEntity"/> instance against which the business
        /// rules are evaulated.</param>
        private void EvaulateRule(string ruleName, TEntity entity)
        {
            //Guard.Against<ArgumentNullException>(entity == null, "Cannot evaulate a business rule set against a null reference.");
            if (_ruleSets.ContainsKey(ruleName))
            {
                _ruleSets[ruleName].Evaluate(entity);
            }
        }
        #endregion
    }
}