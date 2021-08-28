using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using CommunityTraining.Application.CQRS.PlayLists.Commands;
using CommunityTraining.Applicatoin.SqlEF;
using CommunityTraining.Application.CQRS;
using CommunityTraining.Application.Common;
using FluentValidation;
using CommunityTraining.Application.CQRS.PlayLists.Validators;
using CommunityTraining.Presentation.Api.Filters;
using System.Collections.Generic;
using System;
using CommunityTraining.Presentation.Api.Filters.Handler;
using CommunityTraining.Domain.Common.Exceptions;
using FluentValidationWithCQRSDemo.Filters.Handler;

namespace CommunityTraining.Presentation.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureEFLayer(Configuration);
            services.ConfigureCQRSLayer();
            services.AddValidatorsFromAssembly(typeof(PlayListUpdateCommandValidator).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddControllersWithViews(options => 
            {
                options.Filters.Add(new ApiExceptionFilterAttribute(
                        new Dictionary<Type, IExceptionHandler>()
                        {
                            { typeof(EntityNotFoundException), new EntityNotFoundExceptionHandler() },
                            { typeof(GeneralException), new GeneralExceptionHandler() },
                            { typeof(ValidationException), new ValidationExceptionHandler() }
                        }
                    ));
            });
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
