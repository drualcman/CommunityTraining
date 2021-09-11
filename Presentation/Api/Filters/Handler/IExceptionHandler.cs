using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Api.Filters.Handler
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}
