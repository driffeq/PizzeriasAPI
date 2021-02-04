using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pizzerias.Domain.Aggregates.PizzeriasAggregate;
using Pizzerias.Domain.SharedKernel;
using Pizzerias.Infrastructure.Behaviours;
using Pizzerias.Infrastructure.Modules.Pizzerias.AddPizza;
using Pizzerias.Infrastructure.Modules.Pizzerias.AddPizzeria;
using Pizzerias.Infrastructure.Repositories.Pizzerias;
using Pizzerias.Infrastructure.UnitOfWork;
using Pizzerias.Persistance;
using Pizzerias.Persistance.Connection;
using Pizzerias.Persistance.Converters;

namespace Pizzerias.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connString = Configuration.GetConnectionString("ConnectionString");
            services.AddScoped<ISqlConnectionFactory>(_ => new SqlConnectionFactory(connString));
            services.AddDbContext<ApplicationContext>(ctx =>
            {
                ctx.UseSqlServer(connString);
                ctx.ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPizzeriaRepository, PizzeriaRepository>();

            services.AddTransient<IValidator<AddPizzeriaCommand>, AddPizzeriaCommandValidator>();
            services.AddTransient<IValidator<AddPizzaCommand>, AddPizzaCommandValidator>();

            services.AddControllers();
            services.AddMediatR(typeof(AddPizzaCommand));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkResultBehaviour<,>));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pizzerias.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pizzerias.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
