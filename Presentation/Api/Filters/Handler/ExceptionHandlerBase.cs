using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Presentation.Api.Filters.Handler
{
    public class ExceptionHandlerBase
    {
        readonly Dictionary<int, string> RFC7231Types = new Dictionary<int, string>
        {
            { StatusCodes.Status404NotFound, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4"},
            { StatusCodes.Status400BadRequest, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1"},
            { StatusCodes.Status500InternalServerError, "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"}
        };

        public ValueTask SetResult(ExceptionContext context, int? status, string title, string detail = "")
        {
            string type;
            if (status.HasValue) type = RFC7231Types.ContainsKey(status.Value) ? RFC7231Types[status.Value] : "";
            else type = string.Empty;

            ProblemDetails details = new ProblemDetails
            {
                Status = status,
                Title = title,
                Detail = detail,
                Type = type
            };
            context.Result = new ObjectResult(details)
            {
                StatusCode = status
            };
            context.ExceptionHandled = true;
            return ValueTask.CompletedTask;            
        }
    }
}
