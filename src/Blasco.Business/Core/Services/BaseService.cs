using Blasco.Business.Core.Models;
using FluentValidation;

namespace Blasco.Business.Core.Services
{
   public abstract class BaseService
    {
        public bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE: Entity
        {
            var validator = validation.Validate(entity);

            return validator.IsValid;
        }
    }
}
