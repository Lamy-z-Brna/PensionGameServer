using Castle.Facilities.AspNetCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PensionGame.Web.Client;
using PensionGame.Web.Services;
using System;

namespace PensionGame.Web
{
    public class Startup
    {
        private static readonly WindsorContainer _container = new();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<SessionDataServices>();
            services.AddSingleton<GameDataServices>();

            RegisterApplicationComponents(services);

            //services.AddWindsor(_container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }

        private void RegisterApplicationComponents(IServiceCollection services)
        {
            //RegisterAllImplementing(typeof(IRestConnectionConfiguration));
            //RegisterAllImplementing(typeof(IServiceClient));
        }

        private void RegisterAllImplementing(Type type)
        {
            _container.Kernel.Register(
                Classes.FromAssemblyContaining(type)
                    .BasedOn(type)
                    .WithServiceAllInterfaces()
                );
        }
    }
}
