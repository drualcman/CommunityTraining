using CommunityTraining.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Api.Filters.Handler
{
    public class EntityNotFoundExceptionHandler : ExceptionHandlerBase, IExceptionHandler
    {
        public Task Handle(ExceptionContext context)
        {
            EntityNotFoundException exception = context.Exception as EntityNotFoundException;
            return SetResult(context, StatusCodes.Status404NotFound, "El recurso expecificado no fue encontrado",
                $"Recurso {exception.Entity} {exception.Key} no encontrado").AsTask();
        }
    }
}
