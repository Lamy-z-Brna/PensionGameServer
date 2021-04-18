using Castle.Facilities.AspNetCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PensionGame.Api.Common.Mappers;
using PensionGame.Api.Common.Profiles;
using PensionGame.Api.Data_Access.Connection;
using PensionGame.Api.Data_Access.ConnectionSettings;
using PensionGame.Api.Data_Access.Readers;
using PensionGame.Api.Data_Access.Writers;
using PensionGame.Api.Domain.Validation.Validators;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Common;
using PensionGame.Host.Exception_Handling;
using PensionGame.Host.Validation;
using System;
using System.Reflection;
using System.Text.Json.Serialization;

namespace PensionGame.Host
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<GameStateConnectionSettings>(
                Configuration.GetSection(nameof(GameStateConnectionSettings)));

            services.Configure<SessionConnectionSettings>(
                Configuration.GetSection(nameof(SessionConnectionSettings)));

            services.AddSingleton(sp => sp.GetRequiredService<IOptions<GameStateConnectionSettings>>().Value);

            services.AddSingleton(sp => sp.GetRequiredService<IOptions<SessionConnectionSettings>>().Value);

            services.AddSingleton<GameStateDatabase>();

            services.AddSingleton<SessionDatabase>();

            services.AddControllers(options =>
                {
                    options.Filters.Add(typeof(ValidateModelAttribute));
                    options.Filters.Add(typeof(ExceptionHandlingAttribute));
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                })
                .AddFluentValidation(fv
                    => fv.RegisterValidatorsFromAssemblyContaining<StartupParametersValidator>());
            services.AddAutoMapper(Assembly.GetAssembly(typeof(CoreToResourcesProfile)));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PensionGame.Host", Version = "v1" });
            });

            RegisterApplicationComponents(services);

            services.AddWindsor(_container);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
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
            _container.Register(Component.For<IRandomSampler>()
                .ImplementedBy<RandomSampler>());
            RegisterAllImplementing<IReader>();
            RegisterAllImplementing<IWriter>();
            RegisterAllImplementing(typeof(ICalculatorParameters));
            RegisterAllImplementing(typeof(ICalculator<>));
            RegisterAllImplementing(typeof(ICalculator<,>));
            RegisterAllImplementing(typeof(IMapper<,>));
            RegisterAllImplementing(typeof(IQueryHandler<,>));
            RegisterAllImplementing(typeof(ICommandHandler<>));
            RegisterAllImplementing(typeof(ICommandHandler<,>));
            _container.Register(Component.For<IDispatcher>()
                .ImplementedBy<Dispatcher>());
        }

        private void RegisterAllImplementing<T>()
        {
            _container.Kernel.Register(
                Classes.FromAssemblyContaining(typeof(T))
                    .BasedOn(typeof(T))
                    .WithServiceAllInterfaces()
                );
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
