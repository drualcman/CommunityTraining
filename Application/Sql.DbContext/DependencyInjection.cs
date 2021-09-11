using CommunityTraining.Domain.Common.Interfaces;
using CommunityTraining.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Applicatoin.SqlEF
{
    public static class DependencyInjection
    {
        public static void ConfigureEFLayer(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<PlayListDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Default")));
            //add interfaces to manage the inverse injection
            services.AddScoped(typeof(IAddContext<PlayList>), typeof(PlayListRepositoryEF));
            services.AddScoped(typeof(IUpdateContext<PlayList>), typeof(PlayListRepositoryEF));
            services.AddScoped(typeof(IDeleteContext<PlayList>), typeof(PlayListRepositoryEF));
            services.AddScoped(typeof(IGetAllContext<PlayList>), typeof(PlayListRepositoryEF));
            services.AddScoped(typeof(IGetContext<PlayList>), typeof(PlayListRepositoryEF));
        }
    }
}
