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
            services.AddTransient<IAddVideoInputPort, AddVideoInteractor>();
            services.AddTransient<IUpdateVideoInputPort, UpdateVideoInteractor>();
            services.AddTransient<IGetVideoInputPort, GetVideoInteractor>();
            services.AddTransient<IAllVideoInputPort, AllVideoInteractor>();
            services.AddTransient<IAllVideoOutputPort, AllVideoPresenter>();
            services.AddTransient<IEditVideoOutputPort, EditVideoPresenter>();
            services.AddTransient<IDeleteVideoInputPort, DeleteVideoInteractor>();
            services.AddTransient<IDeleteVideoOutputPort, DeleteVideoPresenter>();
        }
    }
}
