﻿using BusinessRulesAndValidationsRules.Rules.Utils;

namespace BusinessRulesAndValidationsRules.Rules.Validator
{
    /// <summary>
    /// Interface implemented by different flavors of validators that provide validation
    /// logic on domain entities.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IEntityValidator<TEntity>
    {
        /// <summary>
        /// Validates an entity against all validations defined for the entity.
        /// </summary>
        /// <param name="entity">The <typeparamref name="TEntity"/> to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> that contains the results of the validation.</returns>
        ValidationResult Validate(TEntity entity);
    }
}