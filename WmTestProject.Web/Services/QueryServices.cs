using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WmTestProject.Application.Queries.Product;
using WmTestProject.Implementation.Queries.Product;

namespace WmTestProject.Web.Services
{
    public static class QueryServices
    {
        public static IServiceCollection RegisterQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetProductsQuery, GetProductsQuery>();

            return services;
        }
    }
}
