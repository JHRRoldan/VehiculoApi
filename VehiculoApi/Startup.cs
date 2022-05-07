using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using VehiculosContext.Vehiculos;
using VehiculosService.Service;
using e = VehiculosService.Service;


namespace VehiculoApi
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
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VehiculoApi", Version = "v1" });
            });

            #region Injección de dependencias de contexto
            services.AddDbContext<VehiculoContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DataBase"),
            b => b.MigrationsAssembly("VehiculosContext")));
            #endregion

            #region Injección de dependencias
            services.AddScoped<IVehiculosService, e.VehiculosService>();
            #endregion

            #region AutoMapper

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VehiculoApi v1"));
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
