using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PruebaTecnicaNet.Business.Service;
using PruebaTecnicaNet.Contract.Contracts;
using PruebaTecnicaNet.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaNet.API
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
         
            services.AddControllers();

            //Customer Service
            services.AddScoped<ICustomerService, CustomerService>();
            //Order Service
            services.AddScoped<IOrderService, OrderService>();
            //Products Service
            services.AddScoped<IProductService, ProductService>();
            //Agregando Conexión Con la DB
            services.AddDbContext<PruebaTecnicaNetSqlContext>(ops =>
            {
                string dbConnection = Configuration.GetConnectionString("PruebaTecnicaNet");

                ops.UseSqlServer(dbConnection);
            });

            //AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PruebaTecnicaNet.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PruebaTecnicaNet.API v1"));
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
