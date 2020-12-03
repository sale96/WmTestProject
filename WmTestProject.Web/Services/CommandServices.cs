using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WmTestProject.Application.Commands.Product;
using WmTestProject.Implementation.Commands.ProductCommands;

namespace WmTestProject.Web.Services
{
    public static class CommandServices
    {
        public static IServiceCollection RegisterCommands(this IServiceCollection services)
        {
            services.AddTransient<IAddProductCommand, AddProductCommand>();

            return services;
        }
    }
}
