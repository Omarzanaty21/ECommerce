using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB.Extensions
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthenticationExtensions(this IServiceCollection services)
        {
            services.AddAuthentication()
                .AddCookie("admin", config => {
                    config.LoginPath = "/dashboard/login";
                    config.LogoutPath = "/dashboard/logout";
                    config.AccessDeniedPath = "/dashboard/error";
                });

            return services;
        }
    }
}