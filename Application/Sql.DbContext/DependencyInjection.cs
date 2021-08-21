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
            services.AddScoped(typeof(IPlayListAddContext<>), typeof(RepositoryEF<>));
            services.AddScoped(typeof(IPlayListUpdateContext<>), typeof(RepositoryEF<>));
            services.AddScoped(typeof(IPlayListDeleteContext<>), typeof(RepositoryEF<>));
            services.AddScoped(typeof(IPlayListGetAllContext<>), typeof(RepositoryEF<>));
            services.AddScoped(typeof(IPlayListGetContext<>), typeof(RepositoryEF<>));
        }
    }
}
