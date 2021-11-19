using CommunityTraining.Application.Ports.VideoPorts;
using CommunityTraining.Application.UseCases.Validators;
using CommunityTraining.Application.UseCases.VideoCases;
using CommunityTraining.Interfaces.Presenters.Videos;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CommunityTraining.Application.InversionOfControl
{
    public static class ServicesControlInyection
    {
        public static void AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<IAllVideoOutputPort, AllVideoPresenter>();
            services.AddScoped<IEditVideoOutputPort, EditVideoPresenter>();
            services.AddScoped<IDeleteVideoOutputPort, DeleteVideoPresenter>();
        }
    }
}
