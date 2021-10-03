using CommunityTraining.Application.Ports.VideoPorts;
using CommunityTraining.Application.UseCases.VideoCases;
using Microsoft.Extensions.DependencyInjection;

namespace CommunityTraining.Application.UseCases
{
    public static class ServicesControlInyection
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            //las injecciones para los input y output ports deben de ser por transaccion
            //para evitar errores de asignacion de variables
            services.AddTransient<IAddVideoInputPort, AddVideoInteractor>();
            services.AddTransient<IUpdateVideoInputPort, UpdateVideoInteractor>();
            services.AddTransient<IGetVideoInputPort, GetVideoInteractor>();
            services.AddTransient<IAllVideoInputPort, AllVideoInteractor>();
            services.AddTransient<IDeleteVideoInputPort, DeleteVideoInteractor>();
        }
    }
}
