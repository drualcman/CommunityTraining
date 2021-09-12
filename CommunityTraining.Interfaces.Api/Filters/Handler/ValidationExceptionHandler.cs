using CommunityTraining.Interfaces.Api.Filters.Handler;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentValidationWithCQRSDemo.Filters.Handler
{
    public class ValidationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            ValidationException exception = context.Exception as ValidationException;

            StringBuilder properties = new StringBuilder();
            StringBuilder messages = new StringBuilder();

            foreach (ValidationFailure failure in exception.Errors)
            {
                properties.Append($"{failure.PropertyName},");
                messages.Append($"{failure.ErrorMessage},");
            }
            return SetResult(context, StatusCodes.Status422UnprocessableEntity, properties.ToString(), messages.ToString()).AsTask();
        }
    }
}
