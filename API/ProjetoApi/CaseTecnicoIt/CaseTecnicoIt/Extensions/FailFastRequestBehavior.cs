using CaseTecnicoIt.Application;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Extensions
{
    public class FailFastRequestBehavior
    {

        public class ValidationRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
          where TRequest : IRequest<TResponse> where TResponse : Response
        {
            private readonly IEnumerable<IValidator> _validators;

            public ValidationRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
            {
                _validators = validators;
            }

           

            private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
            {
                var response = new Response();

                foreach (var failure in failures)
                {
                    response.AddError(failure.ErrorMessage);
                }

                return Task.FromResult(response as TResponse);



            }
        }
    }
}
