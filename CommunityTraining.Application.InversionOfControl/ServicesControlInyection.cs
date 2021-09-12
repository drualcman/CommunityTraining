using CommunityTraining.Application.Common;
using CommunityTraining.Application.CQRS;
using CommunityTraining.Application.CQRS.PlayLists.Validators;
using CommunityTraining.Interfaces.SqlEF;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CommunityTraining.Application.InversionOfControl
{
    public static class ServicesControlInyection
    {
        public static void AddServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureEFLayer(configuration);
            services.ConfigureCQRSLayer();
            services.AddValidatorsFromAssembly(typeof(PlayListUpdateCommandValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
