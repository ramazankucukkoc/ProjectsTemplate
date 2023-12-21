using Core.Application.Constants;
using Core.CrossCuttingConcerns.ExceptionHandling.Exceptions;

namespace Core.Application.Rules
{
    public abstract class BaseBusinessRules
    {

        public virtual Task EntityShouldBeExists<T>(T entity)
        {
            if (entity is null) throw new BusinessException(entity.GetType().Name + BaseBusinessRulesMessages.Null);
            return Task.CompletedTask;
        }
    }
}
