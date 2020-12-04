using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WmTestProject.Implementation.Validation;

namespace WmTestProject.Web.Services
{
    public static class ValidatorServices
    {
        public static IServiceCollection RegisterValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateProductValidation>();
            services.AddTransient<CreateProductJsonValidation>();

            return services;
        }
    }
}
