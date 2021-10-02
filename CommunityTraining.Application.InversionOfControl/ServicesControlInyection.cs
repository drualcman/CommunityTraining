using CommunityTraining.Application.Ports.VideoPorts;
using CommunityTraining.Application.UseCases.Validators;
using CommunityTraining.Application.UseCases.VideoCases;
using CommunityTraining.Interfaces.Presenters.Videos;
using CommunityTraining.Interfaces.SqlEF;
using FluentValidation;
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
            services.AddValidatorsFromAssembly(typeof(VideoValidator).Assembly);
            services.AddScoped<IAddVideoInputPort, AddVideoInteractor>();
            services.AddScoped<IUpdateVideoInputPort, UpdateVideoInteractor>();
            services.AddScoped<IGetVideoInputPort, GetVideoInteractor>();
            services.AddScoped<IAllVideoInputPort, AllVideoInteractor>();
            services.AddScoped<IAllVideoOutputPort, AllVideoPresenter>();
            services.AddScoped<IEditVideoOutputPort, EditVideoPresenter>();
            services.AddScoped<IDeleteVideoInputPort, DeleteVideoInteractor>();
            services.AddScoped<IDeleteVideoOutputPort, DeleteVideoPresenter>();
        }
    }
}
