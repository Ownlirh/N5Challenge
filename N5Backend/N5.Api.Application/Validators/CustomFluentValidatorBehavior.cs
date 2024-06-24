using FluentValidation;
using MediatR;
using N5.Api.Application.Exceptions;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace N5.Api.Application.Validators;
public class CustomFluentValidatorBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IBaseRequest
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = (await Task.WhenAll(validators.Select((v) => v.ValidateAsync(context, cancellationToken))).ConfigureAwait(false)).Where((ValidationResult r) => r.Errors.Count > 0).SelectMany((ValidationResult r) => r.Errors).ToList();
            var failuresMessage = failures.Select((failure) => failure.ErrorMessage).GetEnumerator();
            if (failures.Count > 0)
            {
                throw new BusinessException("There was one or more errors validating the request sent.")
                {
                    ExceptionData = failuresMessage
                };
            }
        }

        return await next().ConfigureAwait(false);
    }
}
