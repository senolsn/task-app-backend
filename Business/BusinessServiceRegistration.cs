using Business.Abstracts;
using Business.Concretes;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServiceRegistration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
      
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IAuthService,AuthManager>();
            services.AddScoped<ITokenHelper,JwtHelper>();
            services.AddScoped<IProductColorService, ProductColorManager>();
            services.AddScoped<IProductService, ProductManager>();

            return services;
        }
    }
}
