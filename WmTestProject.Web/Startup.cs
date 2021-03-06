using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WmTestProject.Application;
using WmTestProject.DataAccess;
using WmTestProject.DataAccess.JsonContext;
using WmTestProject.DataAccess.JsonContext.Interfaces.Implementations;
using WmTestProject.Implementation.Loggers;
using WmTestProject.Implementation.MappingProfiles;
using WmTestProject.Web.Services;

namespace WmTestProject.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<WmTestContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(WmTestContext).Assembly.FullName));
            });

            services.AddTransient<IJsonProductContext, JsonProductContext>();
            services.AddTransient<IJsonCategoryContext, JsonCategoryContext>();
            services.AddTransient<IJsonManufacturerContext, JsonManufacturerContext>();
            services.AddTransient<IJsonSupplierContext, JsonSupplierContext>();

            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ProductProfile>();
            });

            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<IApplicationLogger, ConsoleLogger>();

            services.RegisterQueries();
            services.RegisterCommands();
            services.RegisterValidators();
        }

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Products}/{action=Index}/{id?}");
            });
        }
    }
}
