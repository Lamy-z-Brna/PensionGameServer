using Castle.Facilities.AspNetCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PensionGame.Api.Common.Mappers;
using PensionGame.Api.Handlers.Common;
using PensionGame.DataAccess.Readers;
using PensionGame.DataAccess.Writers;
using System;

namespace PensionGame.Host
{
    public class Startup
    {
        private static readonly WindsorContainer Container = new WindsorContainer();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PensionGame.Host", Version = "v1" });
            });

            RegisterApplicationComponents(services);

            services.AddWindsor(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PensionGame.Host v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterApplicationComponents(IServiceCollection services)
        {
            RegisterAllImplementing<IReader>();
            RegisterAllImplementing<IWriter>();
            RegisterAllImplementing(typeof(IMapper<,>));
            RegisterAllImplementing(typeof(IValidator<>));
            RegisterAllImplementing(typeof(IQueryHandler<,>));
            RegisterAllImplementing(typeof(ICommandHandler<,>));
            Container.Kernel.Register(
                Classes.FromAssemblyContaining(typeof(ICommandHandler <,>))
                    .BasedOn(typeof(ICommandHandler<,>))                    
                    .WithServiceAllInterfaces()                    
                );
            //Container.Register(Component.For<ICreateSessionCommandHandler>()
            //    .ImplementedBy<CreateSessionCommandHandler>());
        }

        private void RegisterAllImplementing<T>()
        {
            Container.Kernel.Register(
                Classes.FromAssemblyContaining(typeof(T))
                    .BasedOn(typeof(T))
                    .WithServiceAllInterfaces()
                );
        }

        private void RegisterAllImplementing(Type type)
        {
            Container.Kernel.Register(
                Classes.FromAssemblyContaining(type)
                    .BasedOn(type)
                    .WithServiceAllInterfaces()
                );
        }
    }
}
