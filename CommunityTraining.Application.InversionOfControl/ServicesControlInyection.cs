using CommunityTraining.Application.UseCases;
using CommunityTraining.Application.UseCases.Validators;
using CommunityTraining.Interfaces.SqlEF;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CommunityTraining.Application.InversionOfControl
{
    public static class ServicesControlInyection
    {
        public static void AddServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.ConfigureEFLayer(configuration);
            services.AddValidatorsFromAssembly(typeof(VideoValidator).Assembly);
            services.AddUseCases();
            services.AddPresenters();
        }
    }
}
