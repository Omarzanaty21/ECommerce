using System;
using WEB.Services;
using WEB.Interfaces;

namespace WEB.Extensions;

public static class CityServicesExtensions
{
    public static void AddCityService(this IServiceCollection services)
    {
        services.AddTransient<ICityService, CityService>();
    }
}