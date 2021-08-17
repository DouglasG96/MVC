using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVC.Controllers;
using MVC.Entities;
using MVC.Interfaces;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC
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
            services.AddControllersWithViews();
            services.AddTransient<ILogin, LoginModel>();
            services.AddTransient<IPeliculas, PeliculasModel>();
            services.AddTransient<IUsuarios, UsuariosModel>();
            services.AddTransient<IRentas, RentasModel>();
            services.AddTransient<IVentas, VentasModel>();
            services.AddCors();
            services.AddControllers();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();

            // Registro del Contexto de datos como Servicio Cadena conexion
            services.AddDbContext<PeliculasContext>(options =>
               //options.UseSqlServer(Configuration.GetConnectionString("AppConnection2")).EnableSensitiveDataLogging());
               options.UseSqlServer(Configuration.GetConnectionString("AppConnection")).EnableSensitiveDataLogging());
            //options.UseSqlServer(Configuration.GetConnectionString("AppConnection2")).EnableSensitiveDataLogging());
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
