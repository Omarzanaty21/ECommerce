namespace WEB.Extensions;
public static class AuthenticationExtensions
{
    public static void AddAuthenticationExtensions(this IServiceCollection services)
    {
        services.AddAuthentication("user")
            .AddCookie("admin", config => {
                config.LoginPath = "/dashboard/login";
                config.LogoutPath = "/dashboard/logout";
                config.AccessDeniedPath = "/dashboard/error";
            })
            .AddCookie("user", config => 
            {
                config.LoginPath = "/Account/SignIn";
            });
    }
}