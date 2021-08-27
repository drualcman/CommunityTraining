using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Presentation.Api.Filters.Handler
{
    public class GeneralExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            return SetResult(context, StatusCodes.Status500InternalServerError, "Ha ocurrido un error al procesar la peticion.",
                context.Exception.Message).AsTask();
        }
    }
}
