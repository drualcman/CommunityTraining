using CommunityTraining.Interfaces.Api.Filters.Handler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces.Api.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        readonly IDictionary<Type, IExceptionHandler> ExceptionsHandlers;
        public ApiExceptionFilterAttribute(IDictionary<Type, IExceptionHandler> exceptionsHandlers) =>
            ExceptionsHandlers = exceptionsHandlers;

        public override void OnException(ExceptionContext context)
        {
            Type exceptionType = context.Exception.GetType();

            // Buscar el manejador de la excepcion
            if (ExceptionsHandlers.ContainsKey(exceptionType))
            {
                // Manejar la excepcion
                ExceptionsHandlers[exceptionType].Handle(context);
            }
            else
            {
                // excepcions sin manejador
                new ExceptionHandlerBase().SetResult(context, StatusCodes.Status500InternalServerError,
                    context.Exception.Message, context.Exception.InnerException?.Message);
            }

            base.OnException(context);
        }
    }
}
