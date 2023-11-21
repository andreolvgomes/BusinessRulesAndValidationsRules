namespace BusinessRulesAndValidationsRules.Rules.Business
{
    public interface IBusinessRulesEvaluator<TEntity>
    {
        void Evaulate(TEntity entity);
    }
}