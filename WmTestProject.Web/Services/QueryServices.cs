﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WmTestProject.Application.Queries.Categories;
using WmTestProject.Application.Queries.Product;
using WmTestProject.Implementation.Queries.CategoryQueries;
using WmTestProject.Implementation.Queries.ProductQueries;

namespace WmTestProject.Web.Services
{
    public static class QueryServices
    {
        public static IServiceCollection RegisterQueries(this IServiceCollection services)
        {
            // EntityFramework
            services.AddTransient<IGetProductsQuery, GetProductsQuery>();
            services.AddTransient<IGetCategoriesQuery, GetCategoriesQuery>();

            //Json
            services.AddTransient<IGetProductsJsonQuery, GetProductsJsonQuery>();

            return services;
        }
    }
}
