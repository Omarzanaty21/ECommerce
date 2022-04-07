using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB.Interfaces;
using WEB.Services;

namespace WEB.Extensions
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationExtensions(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAccountService<>), typeof(AccountService<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPictureService, PictureService>();
        }
    }
}