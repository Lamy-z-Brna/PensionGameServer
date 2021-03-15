using Castle.Facilities.AspNetCore;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using PensionGame.Api.Common.Mappers;
using PensionGame.Api.Common.Readers;
using PensionGame.Api.Common.Writers;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Execution;
using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Common;
using PensionGame.DataAccess;
using PensionGame.Host.Validators;
using System;

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
            services.AddDbContext<PensionGameDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PensionGameDbConnection"), b => b.MigrationsAssembly("PensionGame.Host")));

            services.AddControllers(options => options.Filters.Add(typeof(ValidateModelAttribute)))
                .AddFluentValidation(fv 
                    => fv.RegisterValidatorsFromAssemblyContaining<StartupParametersValidator>());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PensionGame.Host", Version = "v1" });
            });

            RegisterApplicationComponents(services);

            services.AddWindsor(_container);

            
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
