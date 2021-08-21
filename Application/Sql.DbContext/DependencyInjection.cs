using CommunityTraining.Interfaces.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Sql.EF
{
    public static class DependencyInjection
    {
        public static void ConfigureEFLayer(this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<PlayListDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("Default")));
            //add interfaces to manage the inverse injection
            services.AddScoped(typeof(IAddContext<>), typeof(RepositoryEF<>));
            services.AddScoped(typeof(IUpdateContext<>), typeof(RepositoryEF<>));
            services.AddScoped(typeof(IDeleteContext<>), typeof(RepositoryEF<>));
            services.AddScoped(typeof(IGetAllContext<>), typeof(RepositoryEF<>));
            services.AddScoped(typeof(IGetContext<>), typeof(RepositoryEF<>));
        }
    }
}
