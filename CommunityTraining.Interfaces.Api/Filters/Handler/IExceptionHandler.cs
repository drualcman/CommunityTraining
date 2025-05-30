﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityTraining.Interfaces.Api.Filters.Handler
{
    public interface IExceptionHandler
    {
        Task Handle(ExceptionContext context);
    }
}
