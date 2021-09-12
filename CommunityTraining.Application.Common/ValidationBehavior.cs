using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CommunityTraining.Application.Common
{
    public class ValidationBehavior<RequestType, ResponseType> :
        IPipelineBehavior<RequestType, ResponseType>
        where RequestType : IRequest<ResponseType>
    {
        readonly IEnumerable<IValidator<RequestType>> Validators;
        public ValidationBehavior(IEnumerable<IValidator<RequestType>> validators) => Validators = validators;

        public async Task<ResponseType> Handle(RequestType request, CancellationToken cancellationToken,
            RequestHandlerDelegate<ResponseType> next)
        {
            if (Validators.Any())
            {
                ValidationResult[] validationResults = await Task.WhenAll(
                        Validators.Select(validator => validator.ValidateAsync(request, cancellationToken))
                    );

                List<ValidationFailure> failures = validationResults
                    .Where(validationResult => validationResult.IsValid == false)
                    .SelectMany(validationResult => validationResult.Errors)
                    //.Where(failure => failure != null)
                    .ToList();

                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }
            }
            return await next();
        }
    }
}
